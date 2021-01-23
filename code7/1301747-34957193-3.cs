    public class ProcessorChainBuilder
    {
        public IProcessor Build()
        {
            return new Configuration1Processor(
                    new Configuration2Processor(null)
                );
        }
    }
