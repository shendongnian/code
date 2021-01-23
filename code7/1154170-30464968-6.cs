    public class EventBus
    {
        private Dictionary<Type, List<Action<IEvent>>> actions = new Dictionary<Type, List<Action<IEvent>>>();
        public void Listen<T>(Action<IEvent> callback) where T : IEvent
        {
            if (!actions.ContainsKey(typeof(T)))
            {
                actions.Add(typeof(T), new List<Action<IEvent>>());
            }
            actions[typeof(T)].Add(callback);
        }
        public void ClearCallbacks<T>() where T : IEvent
        {
            actions[typeof (T)] = null;
        }
        public void Send<T>(T @event) where T : IEvent
        {
            if (!actions.ContainsKey(typeof(T)))
            {
                return;
            }
            foreach (var action in actions[typeof(T)])
            {
                action(@event);
            }
        }
    }
    public interface IEvent
    {
    }
