    public interface IFooFactory<TFoo>
        where TFoo : IFoo
    {
        TFoo Create();
    }
    public class XFactory<TFoo> : IFooFactory<TFoo>
        where TFoo : IFoo
    {
        public TFoo Create()
        {
            throw new NotImplementedException();
        }
    }
    public class YFactory<TFoo> : IFooFactory<TFoo>
        where TFoo : IFoo
    {
        public TFoo Create()
        {
            throw new NotImplementedException();
        }
    }
    public class DefaultFactory<TFoo> : IFooFactory<TFoo>
        where TFoo : IFoo
    {
        public TFoo Create()
        {
            throw new NotImplementedException();
        }
    }
