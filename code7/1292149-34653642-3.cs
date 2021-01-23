    [JsonObject(MemberSerialization.OptIn)]
    public class Product
    { 
        [JsonProperty("prodName")]
        public string ProductName {get;set;}
        
        [JsonProperty("ProdID")]
        public int ProductId {get;set;}
    }
    
    [JsonObject(MemberSerialization.OptIn)]
    public class Store
    {
         [JsonProperty("storeid")]
         public string StoreId { get; set; }
         [JsonProperty("storename")]
         public string StoreName { get; set; }
         [JsonProperty("Products")]
         public IList<Product> Products { get; set; }
    }
