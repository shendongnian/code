    public interface IEventHolder
    {
        void Attach();
        void Detach();
    }
    public class EventHolder<H> : IEventHolder
    {
        private Action<H> _add;
        private Action<H> _remove;
        private H _handler;
        public EventHolder(Action<H> add, Action<H> remove, H handler)
        {
            _add = add;
            _remove = remove;
            _handler = handler;
        }
        public void Attach() { _add(_handler); }
        public void Detach() { _remove(_handler); }
    }
