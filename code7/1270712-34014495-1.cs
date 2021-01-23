    class X : IEnumerable<int>, IEnumerable<string>
    {
                private int[] i = new int[5];
                private string[] s = new string[2];
    
                public X()
                {
                    i[0] = 0; i[1] = 1; i[2] = 2; i[3] = 3; i[4] = 4;
                    s[0] = "test"; s[1] = "test2";
                }
    
                public IEnumerator GetEnumerator()
                {
                    return i.GetEnumerator();
                }
    
                IEnumerator<int> IEnumerable<int>.GetEnumerator()
                {
                    return (IEnumerator<int>)i.GetEnumerator();
                }
    
                IEnumerator<string> IEnumerable<string>.GetEnumerator()
                {
                    return (IEnumerator<string>)i.GetEnumerator();
                }
    }
