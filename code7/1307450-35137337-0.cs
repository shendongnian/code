    public class elementDO
    {
        public int AtomicNumber { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal AtomicWeight { get; set; }
        public override string ToString()
        {
            return $"AtomicNumber: {AtomicNumber}. Symbol: {Symbol}. Name: {Name}. AtomicWeight: {AtomicNumber}";
        }
    }
