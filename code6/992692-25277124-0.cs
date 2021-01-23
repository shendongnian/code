    public interface IProduct
    {
        decimal Price { get; set; }
        decimal WeightInKg { get; set; }
        int Stock { get; set; }
    }
    
    public interface IMovie : IProduct
    {
        int Certification { get; set; }
        int RunningTime { get; set; }
    }
