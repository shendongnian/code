    public class ApiController
    {
        private readonly Software _software;
        private readonly BlockingCollection<WorkItem> _workQueue;
        public ApiController(Software software, BlockingCollection<WorkItem> workQueue)
        {
            _software = software;
            _workQueue = workQueue;
        }
        // Async action method optional
        public async Task<SoftwareOutput> ExecuteAsync(SoftwareInput input)
        {
            var tcs = new TaskCompletionSource<SoftwareOutput>();
            var workItem = new WorkItem(input, tcs);
            _workQueue.Add(workItem);
            _software.ForceIdleEvent();
            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
            {
                cts.Token.Register(() => tcs.TrySetCanceled());
                return await tcs.Task;
            }
        }
    }
    public class AddIn
    {
        private readonly Software _software;
        private readonly BlockingCollection<WorkItem> _workQueue;
        public AddIn(Software software, BlockingCollection<WorkItem> workQueue)
        {
            _software = software;
            _workQueue = workQueue;
            _software.Idle += OnSoftwareIdle;
        }
        private void OnSoftwareIdle(object sender, EventArgs e)
        {
            WorkItem workItem;
            while (_workQueue.TryTake(out workItem))
            {
                var softwareOutput = _software.DoSoftwareWork(workItem.Input);
                workItem.TaskCompletionSource.TrySetResult(softwareOutput);
            }
        }
    }
    public class WorkItem
    {
        public WorkItem(SoftwareInput input, TaskCompletionSource<SoftwareOutput> tcs)
        {
            Input = input;
            TaskCompletionSource = tcs;
        }
        public SoftwareInput Input { get; }
        public TaskCompletionSource<SoftwareOutput> TaskCompletionSource { get; }
    }
