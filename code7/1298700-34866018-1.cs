    public interface IProduct {
        string ProductId {get; set; }
        string ProductName {get; set; }
        Double Price {get; set; }
        int minQuantity {get; set; }
        Dictionary<string,string> Comments {get; set; }
    }
