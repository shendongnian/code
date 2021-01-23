    public class Progress<T> : IProgress<T>
    {
        private readonly Action<T> _progressAction;
        public Progress(Action<T> action)
        {
            _progressAction = action;
        }
        public void Report(T value)
        {
            _progressAction?.Invoke(value);
        }
    }
