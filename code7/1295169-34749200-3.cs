    public class Processor
    {
        private readonly Dictionary<Type, ProcessorFactory> _processors;
        public Processor(IEnumerable<ProcessorFactory> processors)
        {
            _processors = processors.ToDictionary<ProcessorFactory, Type>(p => p.ItemType);
        }
        public void Process(IEnumerable items)
        {
            foreach (var item in items)
            {
                var processorFactory = _processors.GetValueOrDefault(item.GetType());
                if (processorFactory == null) continue; // for simplicity
                var processor = processorFactory.GetProcessor();
                processor.Process(item);
            }
        }
    }
