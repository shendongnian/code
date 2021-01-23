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
                    bool isChanged = false;
                    if (_MyStringVar != specificWord) { isChanged = true; }
                    // check for old value to confirm value changed
                    _MyStringVar = value;
                    if (value == specificWord && isChanged) { SpecificCount++; }
                }
            }    
        }
