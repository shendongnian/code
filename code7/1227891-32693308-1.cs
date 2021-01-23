    public interface ITransformer<in TInput, out TOutput>
        {
            TOutput Transform(TInput input);
        }
    
        public interface ITransform<TInput, TOutput>
        {
            TOutput Transform(ITransformer<TInput, TOutput> transformer);
        }
        public class MessageLogs<T> : ITransform<MessageLogs<T>,T>
        {
            
            public T Transform(ITransformer<MessageLogs<T>, T> transformer)
            {
                return transformer.Transform(this);
            }
    
        }
