    public class MyData
    {
        public List<string> Columns { set; get; }
        public List<List<string>> Rows { set; get; }
    }
---
    var data = JsonConvert.DeserializeObject<MyData>(json);
