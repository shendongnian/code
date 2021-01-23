    public class Row
    {
        // Serialize/Deserialize the `key` into it's values.
        public List<string> key { get { return new List<string>() { Date.ToString("yyyy-MM-dd"), Code, Url }; } set { Date = DateTime.Parse(value[0]); Code = value[1]; Url = value[2]; } }
        // Serialize/Deserialize the `value` into `Count`.
        public int value { get { return Count; } set { Count = value; } }
        [ScriptIgnore]
        public DateTime Date { get; set; }
        [ScriptIgnore]
        public string Code { get; set; }
        [ScriptIgnore]
        public string Url { get; set; }
        [ScriptIgnore]
        public int Count { get; set; }
        public override string ToString()
        {
            return Date.ToString("yyyy-MM-dd") + ", " + Code + ", " + Url + ", " + Count;
        }
    }
    public class RootObject
    {
        public List<Row> rows { get; set; }
    }
    public static void _Main(string[] args)
    {
        string json = "{\"rows\":[" +
            "{\"key\":[\"2015-04-01\",\"524\",\"http://www.sampleurl.com/\"],\"value\":1}," +
            "{\"key\":[\"2015-04-01\",\"524\",\"http://www.sampleurl2.com/\"],\"value\":2}," +
            "{\"key\":[\"2015-04-01\",\"524\",\"http://www.sampleurl3.com\"],\"value\":1}" + 
            "]}";
        var jss = new JavaScriptSerializer();
        var example = jss.Deserialize<RootObject>(json);
        foreach (Row r in example.rows)
        {
            Console.WriteLine(r.ToString());
        }
    }
