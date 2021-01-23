    class ReplicationItem
    {
        public ReplicationAction Action { get; set; } // = Create, Update, Delete
        public string ModelName { get; set; } // Model name
        public Guid Id { get; set; } // Unique identified accross whole platfomr
    }
