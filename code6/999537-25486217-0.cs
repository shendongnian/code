    [DataContract]
    class Operation
    {
        [DataMember]
        public string Name;
        OperationManager _manager = new OperationManager();
        public OperationManager Manager { get { return _manager; } }
        [OnDeserializing]
    #if WP7
        internal
    #endif
        void OnDeserializing(StreamingContext c)
        {
            _manager = new OperationManager();
        }
    }
