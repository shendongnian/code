    class foo
        {
            private string _bar;
            public string Bar
            {
                get { return _bar; }
                set { _bar = value; }
            }
    
            public foo Copy()
            {
               foo newc = new foo();
               newc.Bar = this.Bar;
               return newc;
            }
        }
