    public class Res1
    {
        public string Name1   { get; set; }
        public string Name2   { get; set; }
        public bool?   NameDef { get; set; } //mind the ?
    }
    ...
    ...
    List<Res1> list1 = new List<Res1> { };
    list1.Add(new Res1 { Name1 = "testName" });
