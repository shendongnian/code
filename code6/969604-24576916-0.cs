    public interface IBlabla
    {
    }
    public class Blabla : IBlabla
    {
    }
    public class SomeClass
    {
        public string Name { get; set; }
        public IBlabla Blabla { get; set; }
        public SomeClass(IBlabla bla, string named)
        {
            Blabla = bla;
            Name = named;
        }
    }
