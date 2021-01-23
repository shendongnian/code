    public class Poco
    {
        public int Id { get; set; }
        public string Name { get; set; }        
    }
    var anon = new { Id = 1, Title = "Foo" };
    var dto = anon.ConvertTo<Poco>();
    dto.PrintDump();
