    public class MessageLogs :ITransform
    {
        public T Transform<T>(ITransformer<MessageLogs, T> transformer)
        {
            return transformer.Transform(this);
        } 
    }
