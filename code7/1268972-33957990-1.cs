    public class Proto
    {
        public string name {get;set;}
        public Object[] data {get;set;} 
        public override string ToString()
        {
            var dataAsString = data.Aggregate(string.Empty, (current, t) => current + t.ToString());
            return name + dataAsString;  
        }
    }
