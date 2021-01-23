    public class RootObject
    {
        public string user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
---
    var x = JsonConvert.DeserializeObject<List<RootObject>>(resposta);
    foreach (var user in x)
    {
       .....
    }
