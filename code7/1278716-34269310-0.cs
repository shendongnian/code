    class ObjectWithPriority
    {
        public int Id { get; set; }
        private int? priority;
        public int Priority {
            get
            {
                return (priority.HasValue ? priority.Value : (priority = PriorityProvider(this)).Value);
                
            }
            set { priority = value; }
        }
        Func<ObjectWithPriority, int> PriorityProvider { get; set; }
        public ObjectWithPriority(Func<ObjectWithPriority, int> priorityProvider = null)
        {
            PriorityProvider = priorityProvider ?? (obj => 10 * obj.Id);
        }
    }
