    public class RecordReceiver
    {
        // Arbitrary constants
        // You should fetch value from configuration and define sensible defaults
        private static readonly int threshold = 1000;
        private static readonly TimeSpan timeout = TimeSpan.FromMinutes(1);
        
        private readonly object lockObj = new object();
        private List<Record> records = new List<Record>();
        private TaskCompletionSource<int> batchTcs;
        
        public void Receive(Record record)
        {
            lock (lockObj)
            {
                if (records.Count == 0)
                {
                    batchTcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
                    DispatchRecordsAsync(batchTcs.Task);
                }
                records.Add(record);
                if (records.Count >= threshold)
                {
                    batchTcs.TrySetResult(0);
                }
            }
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
