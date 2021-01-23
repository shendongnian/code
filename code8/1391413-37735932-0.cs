    public class Foo : IDisposable
    {
        public Foo()
        {
            ComplexType = new ComplexType();
        }
        public ComplexType ComplexType { get; set; }
        public void Dispose()
        {
            ComplexType = null;
            GC.Collect();
        }
    }
