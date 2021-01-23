    public class ConsoleProgress<T> : IProgress<T>
    {
        private Action<T> action;
    
        public ConsoleProgress(Action<T> action)
        {
            this.action = action;
        }
        public void Report(T value)
        {
            action(value);
        }
    }
