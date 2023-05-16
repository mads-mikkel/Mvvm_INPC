using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        private Player player = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        public PlayerViewModel()
        {

        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string CurrentScore
        {
            get { return $"{player.CurrentScore} pts."; }
            set
            {
                if (value != null && player != null)
                {
                    int newCurrentScore = Convert.ToInt32(value.Split(' ')[0]);
                    if(player.CurrentScore != newCurrentScore)
                    {
                        player.CurrentScore = newCurrentScore;
                        OnPropertyChanged(nameof(CurrentScore));
                    }
                }
            }
        }
    }
}