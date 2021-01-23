    class Projects
    {
        public int ProjectId { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
    class Tasks
    {
        public int TaskId { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
    class Tag
    {
        public int TagId { get; set; }
        public int TypeId { get; set; }
        public int RelationId { get; set; }
    }
