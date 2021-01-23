    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }  
        public string Value { get; set; }
    }
    var data = new Item(...); // or List<Item>() whatever
    var str_data= JsonConvert.SerializeObject<Item>(data);
    Firebase fb = new Firebase(new Uri("https://abcdefg.firebaseio.com/"));
    //Write
    string path = "/path";    // where to keep data in firebase
    string id = fb.Post(path, data);
    //Read back
    string jsonData = fb.Get(path); 
    var data2 = JsonConvert.DeserializeObject<Item>(jsonData);
