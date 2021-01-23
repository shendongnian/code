    public class BLibClass
    {
        public delegate void HandleBEvent();
        public static event HandleBEvent BEvent;
        private static void WhenAHappens()
        {
            BEvent();
        }
        static BLibClass()
        {
            ALibClass.AEvent += WhenAHappens;
        }
        public static void ATrigger()
        {
            ALibClass.ATrigger();
        }
    }
