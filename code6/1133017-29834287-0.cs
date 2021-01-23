    // This class is general...
    public sealed class DelegatingConverter<T> : IModelConverter<IModel>
    {
        private readonly IModelConverter<T> originalConverter;
        public DelegatingConverter(IModelConverter<T> originalConverter)
        {
            this.originalConverter = originalConverter;
        }
        public byte[] ToBytes(IModel model)
        {
            return originalConverter.ToBytes((T) model);
        }
    }
