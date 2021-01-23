    public class Item
    {
        public string itemName { get; set; }
        public string marketValue { get; set; }
        public string minBuyout { get; set; }
        public string historicalPrice { get; set; }
        public string quantity { get; set; }
        public string globalMarketValue { get; set; }
        public string globalMinBuyout { get; set; }
        public string globalHistoricalPrice { get; set; }
        public string globalQuantity { get; set; }
        public string globalSalePrice { get; set; }
    }
    var result = JsonConvert.Deserialize<Dictionary<string, Item>>("json string")
    foreach (var item in result)
	{
        // do what you want with result
	    Debug.WriteLine(item.Key);
	}
