    public static void Main()
    {
        var player = new Player { Level = 1 };
        player.PropertyChanged += (sender, pcEventArgs) =>
        {
              var self = (Player)sender;
              self.Gold += 10;
              Console.WriteLine($"Player has leveled up to level {self.Level} and given 10 gold, gold is now at {self.Gold}.");
        };
    
        for(var i = 0; i < 10; i++)
        {
            player.Level++;
        }
    }
    public class Player : INotifyPropertyChanged
    {
        public int Gold { get; set; }
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
