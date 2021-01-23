    public static void Main()
    {
        var player = new Player { Level = 1 };
        player.PropertyChanged += (sender, pcEventArgs) =>
        {
            var self = (Player)sender;
            if (self.Level == 10)
            {
                Console.WriteLine("Player was given gold.");
            }
        };
    
        for(var i = 0; i < 10; i++)
        {
            player.Level++;
        }
    }
    public class Player : INotifyPropertyChanged
    {
        private int level;
        public int Level
        {
            get
            { 
                return level;
            }
            set 
            {
                level = value;
                OnPropertyChanged(nameof(Level));
            } 
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
