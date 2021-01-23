    public class Calc
    {
            private int result;
            public int Value
            {
                    get { return result; } 
                    set { result = value; }
            }
    
            public void Add(int value)
            {
                result = value + value;
    
            }
    }
