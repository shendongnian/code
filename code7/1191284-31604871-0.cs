    public class MyDictionary : Dictionary<string, string>
    {
        public override int GetHashCode() 
        {
            ...
        }
    
        public override bool Equals(object source) 
        {
            ...
        }
    }
