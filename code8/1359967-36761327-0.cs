    public class GameVm : ViewModelBase
    {
        public GameVm()
        {
            var rnd = new Random();
            health = rnd.Next(100);
            armor = rnd.Next(100);
        }
        public int Health
        {
            get { return health; }
            set
            {
                if (health != value)
                {
                    health = value;
                    OnPropertyChanged();
                }
            }
        }
        private int health;
        public int Armor
        {
            get { return armor; }
            set
            {
                if (armor != value)
                {
                    armor = value;
                    OnPropertyChanged();
                }
            }
        }
        private int armor;
    }
