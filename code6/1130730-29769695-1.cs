    public class Address : ICloneable
    {
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
 
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
