    public class ALibClass
    {
        public delegate void HandleAEvent();
        public static event HandleAEvent AEvent;
        public static void ATrigger()
        {
            AEvent();
        }
    }
