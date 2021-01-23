    class myClass
        {
            private string _MyStringVar;
            public string specificWord = "word";
            public int SpecificCount = 0;
            public string MyStringVar
            {
                get { return _MyStringVar; }
                set
                {
                    _MyStringVar = value;
                    if (value == specificWord) { SpecificCount++; }
                }
            }    
        }
