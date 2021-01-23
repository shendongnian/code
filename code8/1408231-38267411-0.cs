                public class TestClass
                {
                    private void Test()
                    {
                        var json = "{\r\n    \"637640274112277168\": {\r\n        \"listingid\": \"637640274112277168\",\r\n        \"price\": 50,\r\n        \"fee\": 7,\r\n        \"publisher_fee_app\": 730,\r\n        \"publisher_fee_percent\": \"0.10000000149011612\",\r\n        \"currencyid\": \"2005\",\r\n        \"steam_fee\": 2,\r\n        \"publisher_fee\": 5,\r\n        \"converted_price\": 1,\r\n        \"converted_fee\": 2,\r\n        \"converted_currencyid\": \"2003\",\r\n        \"converted_steam_fee\": 1,\r\n        \"converted_publisher_fee\": 1,\r\n        \"converted_price_per_unit\": 1,\r\n        \"converted_fee_per_unit\": 2,\r\n        \"converted_steam_fee_per_unit\": 1,\r\n        \"converted_publisher_fee_per_unit\": 1,\r\n        \"asset\": {\r\n            \"currency\": 0,\r\n            \"appid\": 730,\r\n            \"contextid\": \"2\",\r\n            \"id\": \"6542776191\",\r\n            \"amount\": \"1\"\r\n        }\r\n    },\r\n    \"194035710805671301\": {\r\n        \"listingid\": \"194035710805671301\",\r\n        \"price\": 0,\r\n        \"fee\": 0,\r\n        \"publisher_fee_app\": 730,\r\n        \"publisher_fee_percent\": \"0.10000000149011612\",\r\n        \"currencyid\": \"2001\",\r\n        \"asset\": {\r\n            \"currency\": 0,\r\n            \"appid\": 730,\r\n            \"contextid\": \"2\",\r\n            \"id\": \"6825071309\",\r\n            \"amount\": \"0\"\r\n        }\r\n    }\r\n    }\r\n\r\n";
                        Dictionary<string, NewListedItem> values = JsonConvert.DeserializeObject<Dictionary<string, NewListedItem>>(json);
                    }
                }
                class listinginfo
                {
                    public Dictionary<string, List<NewListedItem>> Items;
                }
                class Asset
                {
                    public string currency { get; set; }
                    public string appid { get; set; }
                    public string contextid { get; set; }
                    public string id { get; set; }
                    public string amount { get; set; }
                }
                class NewListedItem
                {
                    public string listingid { get; set; }
                    public string price { get; set; }
                    public string fee { get; set; }
                    public string publisher_fee_app { get; set; }
                    public string publisher_fee_percent { get; set; }
                    public string steam_fee { get; set; }
                    public string publisher_fee { get; set; }
                    public string converted_price { get; set; }
                    public string converted_fee { get; set; }
                    public string converted_currencyid { get; set; }
                    public string converted_steam_fee { get; set; }
                    public string converted_publisher_fee { get; set; }
                    public string converted_fee_per_unit { get; set; }
                    public string converted_steam_fee_per_unit { get; set; }
                    public string converted_publisher_fee_per_unit { get; set; }
                    public Asset asset { get; set; }
                }
