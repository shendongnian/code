    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class Record
    {
    	private int n;
    	
    	public Record(int n)
    	{
    		this.n = n;
    	}
    	
    	public int N { get { return n; } }
    }
    
    public class RecordReceiver
    {
        // Arbitrary constants
        // You should fetch value from configuration and define sensible defaults
        private static readonly int threshold = 5;
        private static readonly TimeSpan timeout = TimeSpan.FromMilliseconds(100);
    
    	private readonly Stopwatch sw = Stopwatch.StartNew();
        private readonly object lockObj = new object();
        private List<Record> records = new List<Record>();
        private TaskCompletionSource<IEnumerable<Record>> batchTcs;
    	private CancellationTokenSource delayCts;
        private Task dispatchTask;
    
        public Task ReceiveAsync(Record record)
        {
    		Console.WriteLine("Received record {0} ({1})", record.N, sw.ElapsedMilliseconds);
            lock (lockObj)
            {
                if (records.Count == 0)
                {
                    // .NET 4.6
                    //batchTcs = new TaskCompletionSource<IEnumerable<Record>>(TaskCreationOptions.RunContinuationsAsynchronously);
                    //dispatchTask = DispatchRecordsAsync(batchTcs.Task);
    
                    // .NET 4.5.2
                    batchTcs = new TaskCompletionSource<IEnumerable<Record>>();
    				var asyncContinuationsTask = batchTcs.Task
    					.ContinueWith(bt => bt.Result, TaskScheduler.Default);
                    dispatchTask = DispatchRecordsAsync(asyncContinuationsTask);
    				
    		        delayCts = new CancellationTokenSource();
    				Task.Delay(timeout, delayCts.Token)
    					.ContinueWith(
    						dt =>
    						{
    							lock (lockObj)
    							{
    								if (records.Count > 0)
    								{
    									batchTcs.TrySetResult(new List<Record>(records));
    									records.Clear();
    								}
    							}
    						},
    						TaskContinuationOptions.ExecuteSynchronously);
                }
                records.Add(record);
                if (records.Count >= threshold)
                {
                    batchTcs.TrySetResult(new List<Record>(records));
    	            delayCts.Cancel();
    				records.Clear();
                }
    			return dispatchTask;
            }
        }
    
        internal async Task DispatchRecordsAsync(Task<IEnumerable<Record>> batchTask)
        {
            var batchedRecords = await(batchTask);
            foreach (var record in batchedRecords)
    		{
    			Console.WriteLine("Dispatched record {0} ({1})", record.N, sw.ElapsedMilliseconds);
    			await Task.Yield();
    		}
        }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		MainAsync().GetAwaiter().GetResult();
    	}
    	
    	public static async Task MainAsync()
    	{
    		var receiver = new RecordReceiver();
    		var t1 = receiver.ReceiveAsync(new Record(1));
    		await Task.Delay(TimeSpan.FromMilliseconds(300));
    		var t2 = receiver.ReceiveAsync(new Record(2));
    		var t3 = receiver.ReceiveAsync(new Record(3));
    		var t4 = receiver.ReceiveAsync(new Record(4));
    		var t5 = receiver.ReceiveAsync(new Record(5));
    		var t6 = receiver.ReceiveAsync(new Record(6));
    		var t7 = receiver.ReceiveAsync(new Record(7));
    		var t8 = receiver.ReceiveAsync(new Record(8));
    		var t9 = receiver.ReceiveAsync(new Record(9));
    		await Task.Delay(TimeSpan.FromMilliseconds(300));
    		var t10 = receiver.ReceiveAsync(new Record(10));
    		await Task.WhenAll(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
    	}
    }
