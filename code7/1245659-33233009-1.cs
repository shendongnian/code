    class foo
        {
            private string _bar;
            public string Bar
            {
                get { return _bar; }
                set { _bar = value; }
            }
    
            public foo Clone()//Cloning is creating a new reference type with same values as old object
            {
               foo newc = new foo();
               newc.Bar = this.Bar;
               return newc;
            }
        }
