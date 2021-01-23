    class Main
    {
        class X
        {
            private int[] i = new int[5];
            private string[] s = new string[2];
    
            public X()
            {
                i[0] = 0; i[1] = 1; i[2] = 2; i[3] = 3; i[4] = 4;
                s[0] = "test"; s[1] = "test2";
            }
    
            public IEnumerable<string> Strings
            {
                get
                {
                    return s;
                }
            }
    
            public IEnumerable<int> Ints
            {
                get
                {
                    return i;
                }
            }
    
        }
    
        private static void Main(string[] args)
        {
            X x = new X();
    
            foreach (string s in x.Strings)
            { }
    
            foreach (int i in x.Ints)
            { }
        }
    }
