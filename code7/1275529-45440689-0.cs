    [DataContract]
    [KnownType("GetKnownTypes")]
    public abstract class Event
    {
        [DataMember]
        public DateTime AtTime { get; private set; }
        public Event()
        {
            AtTime = DateTime.Now;
        }
        private static Type[] GetKnownTypes()
        {
            return typeof(Event).Assembly.GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Event)))
                .ToArray();
        }
    }
