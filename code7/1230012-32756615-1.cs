    public class EnityWriterAdapter<T> : IEntityWriter<T>
    {
        public EntityWriterAdapter(EntityFrameworkRepository<T> repository) { ... }
    }
    public class EnityReaderAdapter<T> : IEntityReader<T>
    {
        public EnityReaderAdapter(EntityFrameworkRepository<T> repository) { ... }
    }
