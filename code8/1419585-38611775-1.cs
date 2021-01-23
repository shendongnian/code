    using Newtonsoft.Json;
    public class MyMethod(string json)
    {
         MyObject obj = JsonConvert.DeserializeObject<MyObject>(json);
    }
