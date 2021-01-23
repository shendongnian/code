    public class RecordReceiver
    {
        // Arbitrary constants
        // You should fetch value from configuration and define sensible defaults
        private static readonly int threshold = 1000;
        private static readonly TimeSpan timeout = TimeSpan.FromMinutes(1);
        
        private readonly object lockObj = new object();
        private List<Record> records = new List<Record>();
        private TaskCompletionSource<int> batchTcs;
        private Task dispatchTask;
        
        public async Task ReceiveAsync(Record record)
        {
            Task task;
            lock (lockObj)
            {
                if (records.Count == 0)
                {
                    // .NET 4.6
                    //batchTcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
                    //dispatchTask = DispatchRecordsAsync(batchTcs.Task);
                    
                    // .NET 4.5.2
                    batchTcs = new TaskCompletionSource<int>();
                    dispatchTask = DispatchRecordsAsync(batchTcs.Task.ContinueWith(bt => 0, TaskScheduler.Default));
                }
                records.Add(record);
                if (records.Count >= threshold)
                {
                    batchTcs.TrySetResult(0);
                }
                task = dispatchTask;
            }
            await task.ConfigureAwait(false);
        }
        
        internal async Task DispatchRecordsAsync(Task batchTask)
        {
            var delayCts = new CancellationTokenSource();
            var completedTask = await Task.WhenAny(batchTask, Task.Delay(timeout, delayCts.Token)).ConfigureAwait(false);
            IEnumerable<Record> batchedRecords;
            if (completedTask == batchTask)
            {
                delayCts.Cancel();
            }
            lock (lockObj)
            {
                batchedRecords = new List<Record>(records);
                records.Clear();
            }
            
            // TODO: process records with async I/O HTTP requests
        }
    }
