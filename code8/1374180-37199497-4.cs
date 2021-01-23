    public static class TemporalHolder 
    {
        public static Action<string> HeldAction{ get; set; }
    }
    public static class LibSettings
    {
        public static readonly Action<string> TheAction;
        static LibSettings()
        {
            TheAction = TemporalHolder.HeldAction;
        }
        public static void Init()
        { 
            /*Just do nothing as we will use it to fire the constructor*/ 
        }
    }
