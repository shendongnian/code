        public class EventArg<T> : EventArgs
    {
        private T FEventData;
        public EventArg(T Param)
        {
            // TODO: Complete member initialization
            FEventData = Param;
        }
        public T EventData
        {
            get { return FEventData; }
            set { FEventData = value; }
        }
    }
