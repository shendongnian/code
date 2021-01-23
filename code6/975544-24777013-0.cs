    public class AlphaNumericID
    {
        private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
        public int Alpha { get; protected set;}
        public int Numeric { get; protected set; }
    
        public int NumericLenght { get; protected set; }
    
        public string KeyFront { get; protected set; }
        public string KeyEnd { get; protected set; }
    
        public AlphaNumericID(string keyFront, string keyEnd, int numericLength)
        {
            Alpha = 0;
            Numeric = 1;
    
            KeyFront = keyFront;
            KeyEnd = keyEnd;
    
            NumericLenght = numericLength;
        }
    
        public void Increment()
        {
            Numeric++;
    
            if (Numeric == Math.Pow(10, NumericLenght))
            {
                Alpha++;
                Numeric = 1;
    
                if (Alpha == chars.Length)
                    throw new Exception("Overflow!");
            }
        }
    
        public override string ToString()
        {
            return String.Format("{0}-{1}{2}-{3}", KeyFront, chars[Alpha], Numeric.ToString().PadLeft(NumericLenght, '0'), KeyEnd);
        }
    }
