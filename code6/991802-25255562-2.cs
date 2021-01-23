    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }
    
    public class Class1
    {
        public string name { get; set; }
        public Schema[] schema { get; set; }
        public string[][] data { get; set; }
    }
    
    public class Schema
    {
        public string dataType { get; set; }
        public string colName { get; set; }
        public int idx { get; set; }
    }
---
    string json = File.ReadAllText("json.txt");
    Rootobject root = new Rootobject();
    root.Property1 = JsonConvert.DeserializeObject<Class1[]>(json);
