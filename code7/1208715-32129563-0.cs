    Foo json = JsonConvert.DeserializeObject<Foo>(data);
...
    public class Foo
    {
      public string Hash { get; set; }
      public long Size { get; set; }
    }
