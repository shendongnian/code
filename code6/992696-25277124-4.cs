    public class IClothing : IProduct
    {
        int Size { get; set; }
        Color Color { get; set; }
    }
    public class TShirt : IClothing
    {
        public decimal Price { get; set; }
        public decimal WeightInKg { get; set; }
        public int Stock { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; }
    }
