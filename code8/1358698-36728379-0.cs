    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    public class Program
    {
        // Helper property to simplify console output
        public static string TimeString { get { return DateTime.Now.ToString("mm:ss.fff"); } }
        public static void Main(string[] args)
        {
            using (var scheduler = new Scheduler())
            {
                var userID = "1";
                Console.WriteLine(TimeString + " Main: Getting schedule for first time...");
                var sched1 = scheduler.GetScheduleForUser(userID);
                Console.WriteLine(TimeString + " Main: Got schedule: " + sched1);
                Console.WriteLine(TimeString + " Main: Waiting 2 seconds...");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine(TimeString + " Main: Getting schedule for second time...");
                var sched2 = scheduler.GetScheduleForUser(userID);
                Console.WriteLine(TimeString + " Main: Got schedule: " + sched2);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to end . . .");
            Console.ReadKey();
        }
    }
    public class Scheduler : IDisposable
    {
        // Helper property to simplify console output
        public static string TimeString { get { return DateTime.Now.ToString("mm:ss.fff"); } }
        private Dictionary<string, Task> TasksDictionary { get; set; }
        private Dictionary<string, TaskCompletionSource<bool>> TaskCompletionSourcesDictionary { get; set; }
        private Dictionary<string, CancellationTokenSource> CancellationTokenSourcesDictionary { get; set; }
        private Dictionary<string, string> SchedulesDictionary { get; set; }
        public Scheduler()
        {
            TasksDictionary = new Dictionary<string, Task>();
            TaskCompletionSourcesDictionary = new Dictionary<string, TaskCompletionSource<bool>>();
            CancellationTokenSourcesDictionary = new Dictionary<string, CancellationTokenSource>();
            SchedulesDictionary = new Dictionary<string, string>();
        }
        public void Dispose()
        {
            if (TasksDictionary != null)
            {
                if (CancellationTokenSourcesDictionary != null)
                {
                    foreach (var tokenSource in CancellationTokenSourcesDictionary.Values)
                        tokenSource.Cancel();
                    Task.WaitAll(TasksDictionary.Values.ToArray(), 10000);
                    CancellationTokenSourcesDictionary = null;
                }
                TasksDictionary = null;
            }
            CancellationTokenSourcesDictionary = null;
            SchedulesDictionary = null;
        }
        public string GetScheduleForUser(string userID)
        {
            // There's already a schedule, so get it
            if (SchedulesDictionary.ContainsKey(userID))
            {
                Console.WriteLine(TimeString + "     GetSchedule: Already had schedule for user " + userID);
                return SchedulesDictionary[userID];
            }
            // If there's no task yet, start one
            if (!TasksDictionary.ContainsKey(userID))
            {
                Console.WriteLine(TimeString + "     GetSchedule: Starting task for user " + userID);
                var tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;
                TaskCompletionSourcesDictionary.Add(userID, new TaskCompletionSource<bool>());
                var task = (new TaskFactory()).StartNew(() => GenerateSchedule(userID, token, TaskCompletionSourcesDictionary[userID]), token);
                TasksDictionary.Add(userID, task);
                CancellationTokenSourcesDictionary.Add(userID, tokenSource);
                Console.WriteLine(TimeString + "     GetSchedule: Started task for user " + userID);
            }
            // If there's a task running, wait for it
            Console.WriteLine(TimeString + "     GetSchedule: Waiting for first run to complete for user " + userID);
            var temp = TaskCompletionSourcesDictionary[userID].Task.Result;
            Console.WriteLine(TimeString + "     GetSchedule: First run complete for user " + userID);
            return SchedulesDictionary.ContainsKey(userID) ? SchedulesDictionary[userID] : "null";
        }
        private void GenerateSchedule(string userID, CancellationToken token, TaskCompletionSource<bool> tcs)
        {
            Console.WriteLine(TimeString + "         Task: Starting task for userID " + userID);
            bool firstRun = true;
            while (!token.IsCancellationRequested)
            {
                // Simulate work while building schedule
                if (token.WaitHandle.WaitOne(1000))
                    break;
                // Update schedule
                SchedulesDictionary[userID] = "Schedule set at " + DateTime.Now.ToShortTimeString();
                Console.WriteLine(TimeString + "         Task: Updated schedule for userID " + userID);
                // If this was the first run, set the result for the TaskCompletionSource
                if (firstRun)
                {
                    tcs.SetResult(true);
                    firstRun = false;
                }
            }
            Console.WriteLine(TimeString + "         Task: Ended task for userID " + userID);
        }
    }
