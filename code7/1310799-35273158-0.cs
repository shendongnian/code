    public class Foo
    {
        public int Bar { get; set; }
    }
    
    Expression<Func<Foo, bool>> e = item =>
        SqlFunctions.StringConvert((decimal?)item.Bar).Contains("1");
