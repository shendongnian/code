    public static class ProcessorChainBuilder
    {
        public static IProcessor Build()
        {
            return new Configuration1Processor(
                    new Configuration2Processor(null)
                );
        }
    }
