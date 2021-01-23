    namespace Api
    {
    	public class RootElement
        {
    		[JsonProperty("Rows")]
    		public Item Items { get; set; }
    	}
        public class Currency
        {
    		[JsonProperty("ID")]
            public int ID { get; set; }
    		
    		[JsonProperty("Name")]
            public string Name { get; set; }
    		
    		[JsonProperty("ResourceUrl")]
            public string ResourceUrl { get; set; }
        }
        public class RevenueAccountDomestic
        {
    		[JsonProperty("ID")]
            public int ID { get; set; }
    		
    		[JsonProperty("Name")]
            public string Name { get; set; }
    		
    		[JsonProperty("ResourceUrl")]
            public string ResourceUrl { get; set; }
        }
        public class RevenueAccountEU
        {
    		[JsonProperty("ID")]
            public int ID { get; set; }
    		
    		[JsonProperty("Name")]
            public string Name { get; set; }
    		
    		[JsonProperty("ResourceUrl")]
            public string ResourceUrl { get; set; }    
    	}
        public class RevenueAccountOutsideEU
        {
    		[JsonProperty("ID")]
            public int ID { get; set; }
    		
    		[JsonProperty("Name")]
            public string Name { get; set; }
    		
    		[JsonProperty("ResourceUrl")]
            public string ResourceUrl { get; set; }
        }
        public class Item
        {
    		[JsonProperty("ItemId")]
            public int ItemId { get; set; }
    		
    		[JsonProperty("Title")]
            public string Name { get; set; }
    		
    		[JsonProperty("Code")]
            public string Code { get; set; }
    		
    		[JsonProperty("UnitOfMeasurement")]
            public string UnitOfMeasurement { get; set; }
    		
    		[JsonProperty("ItemType")]
            public string ItemType { get; set; }
    		
    		[JsonProperty("VatRate")]
            public VatRate VatRate { get; set; }
    		
    		[JsonProperty("Price")]
            public double Price { get; set; }
    		
    		[JsonProperty("Currency")]
    		public Currency Currency { get; set; }
    		
    		[JsonProperty("RevenueAccountDomestic")]
    		public RevenueAccountDomestic RevenueAccountDomestic { get; set; }
    		
    		[JsonProperty("RevenueAccountOutsideEU")]
    		public RevenueAccountOutsideEU RevenueAccountOutsideEU { get; set; }
    		
    		[JsonProperty("RevenueAccountEU")]
            public RevenueAccountEU RevenueAccountEU { get; set; }
    		
    		[JsonProperty("StocksAccount")]
    		public object StocksAccount { get; set; }
    		
    		[JsonProperty("TotalRows")]
    		public int TotalRows { get; set; }
    		
    		[JsonProperty("CurrentPageNumber")]
    		public int CurrentPageNumber { get; set; }
    		
    		[JsonProperty("PageSize")]
    		public int PageSize { get; set; }
        }
    }
