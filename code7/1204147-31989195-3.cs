    public partial class MyService : ServiceBase
    {
        private readonly List<TaskBase> _tasks; 
        public MyService()
        {
            InitializeComponent();
            // Add in this list the tasks to run periodically.
            // Tasks frequencies are set in the corresponding classes.
            _tasks = new List<TaskBase>
            {
                new InheritingTask(),
                new OherInheritingTask()
            };
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                _tasks.ForEach(t => t.Start());
            }
            catch (Exception ex)
            {
                Stop();
            }
        }
        protected override void OnStop()
        {
            _tasks.ForEach(t => t.Stop());
        }
    }
