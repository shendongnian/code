    public class OrderItemModifier
    {
        public int Id { get; set; }
    
        public override bool Equals(object obj)
        {
            var typedObj = obj as OrderItemModifier;
            return typedObj != null && typedObj.Id = this.Id;
        }
    
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
