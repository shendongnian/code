    public class Stats
    {
        private int STAMINA;
    
        public int Stamina
        {
            get { return STAMINA; }
            set { STAMINA = value; }
        }
    }
    
    public class Profile
    {
        private Stats stats;
        private int PROFILE_STAMINA;
    
        //Init only
        public Profile()
        {
            stats = new Stats();
        }
    
        //Init with Stats stamina and profileStamina stamina values
        public Profile(int stamina, int profileStamina)
        {
            stats = new Stats();
            stats.Stamina = stamina;
            PROFILE_STAMINA = profileStamina;
        }
    
        //Stamina From Profile
        public int profileStamina
        {
            get { return PROFILE_STAMINA; }
            set { PROFILE_STAMINA = value; }
        }
    
        //Stamina From Stats
        public int Stamina
        {
            get { return stats.Stamina; }
            set { stats.Stamina = value; }
        }
    }
