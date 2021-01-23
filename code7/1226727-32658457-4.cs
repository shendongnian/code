    class Database : IRepository
    {
        private readonly IDataReader _reader;
        private readonly IDataWriter _writer;
        private readonly IDataDeleter _deleter;
        public Database(IDataReader reader, IDataWriter writer, IDataDeleter deleter)
        {
            _reader = reader;
            _writer = writer;
            _deleter = deleter;
        }
        public T Get<TModel>(int id) { _reader.Get<TModel>(id); }
        public T Save<TModel>(TModel model) { _writer.Save<TModel>(model); }
        public void Delete<TModel>(TModel model) { _deleter.Delete<TModel>(model); }
        public void Delete<TModel>(int id) { _deleter.Delete<TModel>(id); }
    }
