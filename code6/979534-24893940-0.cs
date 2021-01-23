    var obj  = JsonConvert.DeserializeObject<AClass>(DATA);
    foreach (var data in obj.AttributeData)
    {
        var buf = Convert.FromBase64String(data);
        Console.WriteLine(Encoding.UTF8.GetString(buf));
    }
---
    public class AClass
    {
        public List<string> sa { get; set; }
        public List<string> sb { get; set; }
        public string sz { get; set; }
        public string sid { get; set; }
        public string ti { get; set; }
        public int NumberOfTokens { get; set; }
        public List<string> AttributeData { get; set; }
    }
