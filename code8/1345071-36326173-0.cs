    [JsonObject]
    public class CategoryModel
        {
    
            public int CategoryId { get; set; }
    
            public string CategoryName { get; set; }
    
            public IEnumerable<ItemModel> Items { get; set; }
    
        }
    [JsonObject]
    public class ItemModel
        {
            public int ItemId { get; set; }
            [JsonIgnore] 
            public int CategoryId { get; set; }
            public string ItemName { get; set; }
    
        }
