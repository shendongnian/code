    public class NumberWriterFactory : INumberWriterFactory
    {
        readonly IStream stream;
        readonly IContainer container;
        public NumberWriterFactory(IStream stream, IContainer container)
        {
            this.stream = stream;
            this.container = container;
        }
        public INumberWriter Create(int number)
        {
            return container.Resolve<INumberWriter>(number, this.stream);
        }
        public INumberWriter Create(int number, IStream stream)
        {
            return container.Resolve<INumberWriter>(number, stream);
        }
    }
