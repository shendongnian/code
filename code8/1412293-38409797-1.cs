        public abstract class AsyncClientBase
        {
            protected readonly IAsyncRequestProcessor Processor;
        
            protected AsyncClientBase(IAsyncRequestProcessor processor)
            {
                Processor = processor;
            }
        }
