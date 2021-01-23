    public static class TemporalHolder 
    {
        public static Action<string> HeldAction{ get; set; }
    }
    public static class LibSettings
    {
        public static Action<string> TheAction{ get; private set; }
        static LibSettings()
        {
            TheAction = TemporalHolder.HeldAction;
        }
        public static void Init()
        { 
            /*Just do nothing as we will use it to fire the constructor*/ 
        }
    }
