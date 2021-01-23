    public class FOO 
            {
                private char _foo;
                public char foo 
                {
                    get { return _foo; }
                    set {
                        if (value == 'M' || value == 'F' || value == 'O')
                        {
                            _foo = value;
                        }
                        else 
                        {
                            throw new Exception("invalid Character");
                        }
                  }
                }
            }
