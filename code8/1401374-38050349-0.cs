    public class MyInfo
    {
        public string Name { get; set; }
        public double Diff { get; set; }
        public string File { get; set; }
    }
    static void Main(string[] args)
    {
        PSObject obj = PSObject.AsPSObject(new { Name = "David", Diff = 0.2, File = "output.txt" });
        var serialized = JsonConvert.SerializeObject(obj.Properties.ToDictionary(k => k.Name, v => v.Value));
        Console.WriteLine(serialized);
        var deseialized = JsonConvert.DeserializeObject<MyInfo>(serialized);
        Console.WriteLine($"Name: {deseialized.Name}");
        Console.WriteLine($"Diff: {deseialized.Diff}");
        Console.WriteLine($"File: {deseialized.File}");
    }
