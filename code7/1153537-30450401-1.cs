    public class SD
    {
        public string s { get; set; }
    
        public override bool Equals(object obj)
        {
            return string.Equals(s, (obj as SD).s);
        } 
    
        public override int GetHashCode()
        {
            return s.GetHashCode();
        }
    }
