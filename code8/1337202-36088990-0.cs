    public abstract class DataExtractionMethodConfig<T>
    {
        public abstract DataExtractionMethod DataExtractionMethod { get;  }
        public T DataExtractionConfig { get; protected set; }
    }
