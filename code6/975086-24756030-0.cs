    public class Value
    {
        public List<string> RFCode { get; set; }
        public int Found { get; set; }
        public int Expected { get; set; }
        
        public Value(string s, int found, int expected)
        {
            RFCode = new List<string> { s }; 
            Found = found;
            Expected = expected;
        }
    }
