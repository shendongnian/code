    class DDefinitelyNotB : A
    {
    }
    
    class B :A
    {
        protected int second { get; set; }
    
        public show() {
            A a = new DDefinitelyNotB ();
            a.first = 5;
        }
    }
