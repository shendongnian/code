    using Xamarin.Forms;
    
    namespace KeyboardDemo
    {
        public static class Keyboards
        {
            public static Keyboard Unassisted { get; private set; }
    
            static Keyboards ()
            {
                Unassisted = Keyboard.Create (0);
            }
        }
    }
