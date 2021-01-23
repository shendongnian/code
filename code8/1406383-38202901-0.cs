    public class DataFactory
    {
        private Dictionary<string, IDataGenerator> generators;
    
        public DataFactory(IDataGenerator[] generatorReferences)
        {
            this.generators = generatorReferences
                .ToDictionary(k => k.name, v => v);
        }
        public IDataGenerator Create(string type)
        {
            IDataGenerator generator = null;
            this.generators.TryGetValue(type, out generator);
            return generator;
        }
    }
