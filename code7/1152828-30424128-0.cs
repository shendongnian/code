    public class PriceInfo
    {
       [JsonProperty("success")]
       public string Success { get; set; }
       [JsonProperty("lowest_price")]
       public double LowestPrice { get; set; }
       [JsonProperty("volume")]
       public string Volume { get; set; }
       [JsonProperty("median_price")]
       public string MedianPrice { get; set; }
    }
