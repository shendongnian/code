    public class Delegates
    {
        private List<Action<ISomething>> _delegates;
        public void AddDelegate(Action<ISomething> action)
        {
            _delegates.Add(action);
        }
    }
