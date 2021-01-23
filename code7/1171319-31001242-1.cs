    public class Item
        {
           public int ID {get; set;}
           public string Name{get;set;}
           public int Std {get; set;}
        }
    
    var items = JsonConvert.DeserializeObject<List<Item>>(JsonString);
    
    var newJsonString = JsonConvert.SerializeObject(items.Where(i => i.ID != "ID0000001"));
