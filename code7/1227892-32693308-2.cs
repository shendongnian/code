    public class Transformer<T1,T2> : ITransform<T1,T2>
        {
    
            public T2 Transform(T1 logger,ITransformer<T1, T2> transformer)
            {
                return transformer.Transform(logger);
            }
    
        }
        public class MessageLogs
        {
           // code specific to message logging
        }
