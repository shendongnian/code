    using Newtonsoft.Json;
    
    public class MyMethod(string json)
    {
         <List>MyObject objList = JsonConvert.DeserializeObject<List<MyObject>>(json);
    }
