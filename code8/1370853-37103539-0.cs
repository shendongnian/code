    public class Product {
        public int Rescode {get;set;}
        public int Policyid {get;set;}
        public int InsuredId {get;set;}
    }
    Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);
