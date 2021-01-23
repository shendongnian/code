    public class Delegates<T> where T : ISomething
    {
        private List<Action<T>> _delegates;
        public void AddDelegate(Action<T> action)
        {
            _delegates.Add(action);
        }
    }
