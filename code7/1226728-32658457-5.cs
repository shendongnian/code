    class CompositeWriter : IDataWriter
    {
        public List<IDataWriter> Writers { get; set; }
        public void Save<TModel>(model)
        {
            this.Writers.ForEach(writer =>
            {
                writer.Save<TModel>(model);
            });
        }
    }
    class Database : IRepository
    {
        private readonly IDataReader _reader;
        private readonly IDataWriter _writer;
        private readonly IDataDeleter _deleter;
        private readonly ILogger _logger;
        public Database(IDataReader reader, IDataWriter writer, IDataDeleter deleter, ILogger _logger)
        {
            _reader = reader;
            _writer = writer;
            _deleter = deleter;
            _logger = logger;
        }
        public T Get<TModel>(int id)
        {
            var sw = Stopwatch.StartNew();
            _writer.Get<TModel>(id);
            sw.Stop();
            
            _logger.Info("Get Time: " + sw. ElapsedMilliseconds);
        }
        public T Save<TModel>(TModel model)
        {
             //this will execute the Save method for every writer in the CompositeWriter
             _writer.Save<TModel>(model);
        }
        ... other methods omitted
    }
