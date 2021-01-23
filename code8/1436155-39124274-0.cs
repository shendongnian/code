    private readonly ConcurrentDictionary<ClientToken, TaskData> m_tasks;
    class TaskData
    {
        public Task ProcessingTask { get; set; }
        public BlockingCollection<Message> TaskMessages { get; } =
            new BlockingCollection<Message>();
    }
