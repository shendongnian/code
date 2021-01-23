    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Linq.Expressions;
    using System.Net.NetworkInformation;
    using System.Threading.Tasks;
    
    namespace TestConsoleApplication
    {
        public static class Test
        {
            public static void Main()
            {
                TaskRunningTest();
            }
    
            private static void TaskRunningTest()
            {
                var s = new Stopwatch();
                const int totalInformationChunks = 50000;
                var baseProcessorTaskArray = new Task[Environment.ProcessorCount];
                var taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
                var tcs = new TaskCompletionSource<int>();
    
                var itemsToProcess = new BlockingCollection<Tuple<Information, Address>>(totalInformationChunks);
    
                s.Start();
                //Start a new task to populate the "itemsToProcess"
                taskFactory.StartNew(() =>
                {
                    // Add Tuples of Information and Address to which this information is to be sent to.
                    Console.WriteLine("Done intializing all the jobs...");
                    // Finally signal that you are done by saying..
                    itemsToProcess.CompleteAdding();
                });
    
                //Initializing the base tasks
                for (var index = 0; index < baseProcessorTaskArray.Length; index++)
                {
                    var thisIndex = index;
                    baseProcessorTaskArray[index] = taskFactory.StartNew(() =>
                    {
                        while (!itemsToProcess.IsAddingCompleted && itemsToProcess.Count != 0)
                        {
                            Tuple<Information, Address> item;
                            itemsToProcess.TryTake(out item);
                            //Process the item
                            tcs.TrySetResult(thisIndex);
                        }
                    });
                }
    
                // Need to provide new timeout logic now
                // Depending upon what you are trying to achieve with timeout, you can devise out the way
    
                // Wait for the base tasks to completely empty OR
                // timeout and then stop the stopwatch.
                Task.WaitAll(baseProcessorTaskArray); 
                s.Stop();
                Console.WriteLine(s.ElapsedMilliseconds);
            }
    
            private class Address
            {
                //This class should have the socket information
            }
    
            private class Information
            {
                //This class will have the Information to send
            }
        }
    }
