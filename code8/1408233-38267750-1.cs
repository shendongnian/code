     public class Asset
        {
            public string Currency { get; set; }
            public string Appid { get; set; }
            public string Contextid { get; set; }
            public string Id { get; set; }
            public string Amount { get; set; }
        }
        public class NewListedItem
        {
    
            public string Listingid { get; set; }
            public string Price { get; set; }
            public string Fee { get; set; }
            [JsonProperty("publisher_fee_app")]
            public string PublisherFeeApp { get; set; }
            [JsonProperty("publisher_fee_percent")]
            public string PublisherFeePercent { get; set; }
            [JsonProperty("steam_fee")]
            public string SteamFee { get; set; }
            [JsonProperty("publisher_fee")]
            public string PublisherFee { get; set; }
            [JsonProperty("converted_price")]
            public string ConvertedPrice { get; set; }
            [JsonProperty("converted_fee")]
            public string ConvertedFee { get; set; }
            [JsonProperty("converted_currencyid")]
            public string ConvertedCurrencyid { get; set; }
            [JsonProperty("converted_steam_fee")]
            public string ConvertedSteamFee { get; set; }
            [JsonProperty("converted_publisher_fee")]
            public string ConvertedPublisherFee { get; set; }
            [JsonProperty("converted_fee_per_unit")]
            public string ConvertedFeePerUnit { get; set; }
            [JsonProperty("converted_steam_fee_per_unit")]
            public string ConvertedSteamFeePerUnit { get; set; }
            [JsonProperty("converted_publisher_fee_per_unit")]
            public string ConvertedPublisherFeePerUnit { get; set; }
            public Asset Asset { get; set; }
    
    
        }
