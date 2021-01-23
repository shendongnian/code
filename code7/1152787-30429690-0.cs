    public class Sector
    {
        public Int64 X { get; set; }
        public Int64 Y { get; set; }
    
        [InverseProperty("Sector")] 
        public virtual ICollection<Ship> Ships { get; set; }
    }
    
