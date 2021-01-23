    public class MatchItem : IEquatable<MatchItem>
    {
        public int SomeInt { get; set; }
        public decimal SomeDecimal {get; set; }
        
        public bool Equals(MatchItem item)
        {
            if(item == null)
                return false;
            
            return this.SomeInt == item.SomeInt && this.SomeDecimal == item.SomeDecimal;
        }
        // You should also override object.ToString, object.Equals & object.GetHashCode. 
        // Omitted for brevity here!
    }
