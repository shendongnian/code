    public class FooBarCounter{
        private const int DEFAULTVALUE = 0;
        
        [DefaultValue(DEFAULTVALUE)]
        public int FooCounter1 { get; private set; }
        [DefaultValue(DEFAULTVALUE)]
        public int FooCounter2 { get; private set; }
        // and so on ...
    }
