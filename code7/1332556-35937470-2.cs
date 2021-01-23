    public class ProductApi
    {
        public int Id {get;set;}
        public string Name { get; set; }
    }
    
    public class ResponseDTO
    {
        public int Status {get;set;}
        public List<ProductApi> { get; set; }
    }
