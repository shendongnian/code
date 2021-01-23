    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }  
        public string Value { get; set; }
    }
    dynamic data = JsonConvert.DeserializeObject<dynamic>(jsonString);
    var list = new List<Item>();
    foreach (var itemDynamic in data)
    {
         list.Add(JsonConvert.DeserializeObject<Item>  (((JProperty)itemDynamic).Value.ToString()));
    }
