    static void Main(string[] args)
    {
        var s = "\"11565\",\"a\",\"012\",\"4.5\",\"01\",\"555\"\r\n";
        using (var sr = new StringReader(s))
        {
            var csv = new CsvReader(sr);
            csv.Configuration.HasHeaderRecord = false;
            csv.Configuration.RegisterClassMap<MyClassMap>();
            while (csv.Read())
            {
                var record = csv.GetRecord<MyClass>();
            }
        }
    }
    public class MyClass
    {
        public string Test { get; set; }
        public string TimeclockCode { get; set; }
    }
    public sealed class MyClassMap : CsvClassMap<MyClass>
    {
        public MyClassMap()
        {
            Map(p => p.TimeclockCode).Index(0);
            Map(p => p.Test).Index(2);
        }
    }
