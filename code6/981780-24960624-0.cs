    public interface IInteractionRequestWrapper<T>
    {
        void Request(T instance);
    }
    
    public class InteractionRequestWrapper<T> : IInteractionRequestWrapper<T>
    {
        private InteractionRequest<T> _saveDialogRequest;
    
        public InteractionRequestWrapper()
        {
            _saveDialogRequest = new InteractionRequest<T>();
        }
        public void Request(T instance)
        {
            _saveDialogRequest.Request(instance);
        }
    }
