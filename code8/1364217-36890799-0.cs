        public class ReceiverBase<T> where T : IInterpreter
        {
        }
    
        public interface IInterpreter
        {
        }
    
        public class SpecialReceiver<T> : ReceiverBase<T>
            where T : IInterpreter
        {
        }
    
        public class OwnInterpreter : IInterpreter
        {
        }
    
        public class ReceiverFactory<T> where T : IInterpreter, new()
        {
            public ReceiverBase<T> Create(string type)
            {
                switch (type)
                {
                    default:
                        return new SpecialReceiver<T>();
                }
            }
        }
