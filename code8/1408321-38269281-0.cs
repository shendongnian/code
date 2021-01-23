    class Foo {
        public List<string> Bars { get; private set; }        
        public Foo(List<string> bars) 
        { 
            if (bars!= null && bars.Count > 0)
            {
             this.Bars = bars
            }
        }
    }
