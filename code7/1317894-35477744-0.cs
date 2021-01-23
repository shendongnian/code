    public int PriceId {get; set;}
    
    // The PriceType will recognise among different type of price- Sell Price,          Purchase Price etc.
    public string PriceType{get;set;}
    // foreign key to Product:
    public int ProductId {get; set;}
    public Product Product {get; set;}
    public DateTime ActivationDate {get; set;}
    public decimal value {get; set;}
}
