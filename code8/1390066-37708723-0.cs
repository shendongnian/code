    public class Product
    {
        public static readonly string[] defPriceInfo = { "price", "avgprice", "maxprice" };
        public static readonly string[] defOrderInfo = { "first", "second", "third" };
        [JsonProperty("price")]
        [JsonConverter(typeof(ArrayToDictionaryConverter), typeof(Product), "defPriceInfo")]
        public Dictionary<string, object> priceInfo;
        [JsonProperty("order")]
        [JsonConverter(typeof(ArrayToDictionaryConverter), typeof(Product), "defOrderInfo")]
        public Dictionary<string, object> orderInfo;
    }
