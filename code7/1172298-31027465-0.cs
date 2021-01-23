    public class SecondIndexComparer : IEqualityComparer<string[]>
    {
        public bool Equals(string[] x, string[] y)
        {
            return x[1] == y[1];
        }
    
        public int GetHashCode(string[] obj)
        {
            return obj[1].GetHashCode();
        }
    }
