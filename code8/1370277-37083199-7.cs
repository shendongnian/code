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
    	// I chose a low value so the example wouldn't timeout in .NET Fiddle
        private static readonly TimeSpan timeout = TimeSpan.FromMilliseconds(100);
    	
    	// I'll use a Stopwatch to trace execution times
    	private readonly Stopwatch sw = Stopwatch.StartNew();
    	// Using a separate private object for locking
        private readonly object lockObj = new object();
    	// The list of accumulated records to execute in a batch
        private List<Record> records = new List<Record>();
    	// The most recent TCS to signal completion when:
    	// - the list count reached the threshold
    	// - enough time has passed
        private TaskCompletionSource<IEnumerable<Record>> batchTcs;
    	// A CTS to cancel the timer-based task when the threshold is reached
    	// Not strictly necessary, but it reduces resource usage
    	private CancellationTokenSource delayCts;
    	// The task that will be completed when a batch of records has been dispatched
        private Task dispatchTask;
    	
    	// This method doesn't use async/await,
    	// because we're not doing an async flow here.
        public Task ReceiveAsync(Record record)
        {
    		Console.WriteLine("Received record {0} ({1})", record.N, sw.ElapsedMilliseconds);
            lock (lockObj)
            {
    			// When the list of records is empty, set up the next task
    			//
    			// TaskCompletionSource is just what we need, we'll complete a task
    			// not when we've finished some computation, but when we reach some criteria
    			//
    			// This is the main reason this method doesn't use async/await
                if (records.Count == 0)
                {
    				// I want the dispatch task to run on the thread pool
    				
    				// In .NET 4.6, there's TaskCreationOptions.RunContinuationsAsynchronously
                    // .NET 4.6
                    //batchTcs = new TaskCompletionSource<IEnumerable<Record>>(TaskCreationOptions.RunContinuationsAsynchronously);
                    //dispatchTask = DispatchRecordsAsync(batchTcs.Task);
    				
    				// Previously, we have to set up a continuation task using the default task scheduler
                    // .NET 4.5.2
                    batchTcs = new TaskCompletionSource<IEnumerable<Record>>();
    				var asyncContinuationsTask = batchTcs.Task
    					.ContinueWith(bt => bt.Result, TaskScheduler.Default);
                    dispatchTask = DispatchRecordsAsync(asyncContinuationsTask);
    				
    				// Create a cancellation token source to be able to cancel the timer
    				//
    				// To be used when we reach the threshold, to release timer resources
    		        delayCts = new CancellationTokenSource();
    				Task.Delay(timeout, delayCts.Token)
    					.ContinueWith(
    						dt =>
    						{
    							// When we hit the timer, take the lock and set the batch
    							// task as complete, moving the current records to its result
    							lock (lockObj)
    							{
    								// Avoid dispatching an empty list of records
    								//
    								// Also avoid a race condition by checking the cancellation token
    								//
    								// The race would be for the actual timer function to start before
    								// we had a chance to cancel it
    								if ((records.Count > 0) && !delayCts.IsCancellationRequested)
    								{
    									batchTcs.TrySetResult(new List<Record>(records));
    									records.Clear();
    								}
    							}
    						},
    						// Since our continuation function is fast, we want it to run
    						// ASAP on the same thread where the actual timer function runs
    						//
    						// Note: this is just a hint, but I trust it'll be favored most of the time
    						TaskContinuationOptions.ExecuteSynchronously);
    				// Remember that we want our batch task to have continuations
    				// running outside the timer thread, since dispatching records
    				// is probably too much work for a timer thread.
                }
    			// Actually store the new record somewhere
                records.Add(record);
    			// When we reach the threshold, set the batch task as complete,
    			// moving the current records to its result
    			//
    			// Also, cancel the timer task
                if (records.Count >= threshold)
                {
                    batchTcs.TrySetResult(new List<Record>(records));
    	            delayCts.Cancel();
    				records.Clear();
                }
    			// Return the last saved dispatch continuation task
    			//
    			// It'll start after either the timer or the threshold,
    			// but more importantly, it'll complete after it dispatches all records
    			return dispatchTask;
            }
        }
    	
    	// This method uses async/await, since we want to use the async flow
        internal async Task DispatchRecordsAsync(Task<IEnumerable<Record>> batchTask)
        {
    		// We expect it to return a task right here, since the batch task hasn't had
    		// a chance to complete when the first record arrives
    		//
    		// Task.ConfigureAwait(false) allows us to run synchronously and on the same thread
    		// as the completer, but again, this is just a hint
    		//
    		// Remember we've set our task to run completions on the thread pool?
    		//
    		// With .NET 4.6, completing a TaskCompletionSource created with
    		// TaskCreationOptions.RunContinuationsAsynchronously will start scheduling
    		// continuations either on their captured SynchronizationContext or TaskScheduler,
    		// or forced to use TaskScheduler.Default
    		//
    		// Before .NET 4.6, completing a TaskCompletionSource could mean
    		// that continuations ran withing the completer, especially when
    		// Task.ConfigureAwait(false) was used on an async awaiter, or when
    		// Task.ContinueWith(..., TaskContinuationOptions.ExecuteSynchronously) was used
    		// to set up a continuation
    		//
    		// That's why, before .NET 4.6, we need to actually run a task for that effect,
    		// and we used Task.ContinueWith without TaskContinuationOptions.ExecuteSynchronously
    		// and with TaskScheduler.Default, to ensure it gets scheduled
    		//
    		// So, why am I using Task.ConfigureAwait(false) here anyway?
    		// Because it'll make a difference if this method is run from within
    		// a Windows Forms or WPF thread, or any thread with a SynchronizationContext
    		// or TaskScheduler that schedules tasks on a dedicated thread
            var batchedRecords = await batchTask.ConfigureAwait(false);
    		// Async methods are transformed into state machines,
    		// much like iterator methods, but with async specifics
    		//
    		// What await actually does is:
    		// - check if the awaitable is complete
    		//   - if so, continue executing
    		//     Note: if every awaited awaitable is complete along an async method,
    		//           the method will complete synchronously
    		//           This is only expectable with tasks that have already completed
    		//           or I/O that is always ready, e.g. MemoryStream
    		//   - if not, return a task and schedule a continuation for just after the await expression
    		//     Note: the continuation will resume the state machine on the next state
    		//     Note: the returned task will complete on return or on exception,
    		//           but that is something the compiled state machine will handle
            foreach (var record in batchedRecords)
    		{
    			Console.WriteLine("Dispatched record {0} ({1})", record.N, sw.ElapsedMilliseconds);
    			// I used Task.Yield as a replacement for actual work
    			//
    			// It'll force the async state machine to always return here
    			// and shedule a continuation that reenters the async state machine right afterwards
    			//
    			// This is not something you usually want on production code,
    			// so please replace this with the actual dispatch
    			await Task.Yield();
    		}
        }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		// Our main entry point is synchronous, so we run an async entry point and wait on it
    		//
    		// The difference between MainAsync().Result and MainAsync().GetAwaiter().GetResult()
    		// is in the way exceptions are thrown:
    		// - the former aggregates exceptions, throwing an AggregateException
    		// - the latter doesn't aggregate exceptions if it doesn't have to, throwing the actual exception
    		//
    		// Since I'm not combining tasks (e.g. Task.WhenAll), I'm not expecting multiple exceptions
    		//
    		// If my main method returned int, I could return the task's result
    		// and I'd make MainAsync return Task<int> instead of just Task
    		MainAsync().GetAwaiter().GetResult();
    	}
    	
    	// Async entry point
    	public static async Task MainAsync()
    	{
    		var receiver = new RecordReceiver();
    		// I'll provide a few records: 
    		// - a delay big enough between the 1st and the 2nd such that the 1st will be dispatched
    		// - 8 records in a row, such that 5 of them will be dispatched, and 3 of them will wait
    		// - again, a delay big enough that will provoke the last 3 records to be dispatched
    		// - and a final record, which will wait to be dispatched
    		//
    		// We await for Task.Delay between providing records,
    		// but we'll await for the records in the end only
    		//
    		// That is, we'll not await each record before the next,
    		// as that would mean each record would only be dispatched after at least the timeout
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
    		// I probably should have used a list of records, but this is just an example
    		await Task.WhenAll(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
    	}
    }
