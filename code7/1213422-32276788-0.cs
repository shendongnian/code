    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        public static class Test
        {
            //The paths to read and write
            const string OldFilePath = @"C:\Users\Donavon\Desktop\old.sql";
            const string NewFilePath = @"C:\Users\Donavon\Desktop\new.sql";
    
            //The maximum number of lines we can read for parallel processing
            //given the memory restrictions etc. Please set this to a number 
            //that is optimum for you.
            static readonly int ExpectedMaxLines = (int)Math.Pow(2, 10);
            
            //The data structures to hold the old and new lines
            private static readonly BlockingCollection<string> DirtyLines = new BlockingCollection<string>(ExpectedMaxLines);
            private static readonly BlockingCollection<string> CleanLines = new BlockingCollection<string>(ExpectedMaxLines);
    
            //A common factory. Since all tasks are long running, this is enough.
            private static readonly TaskFactory TaskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
    
            public static void Main()
            {
                //Need to start one reader task which will read one line at a time and
                //put that line in the BlockingCollection for parallel processing.
    
                BeginReader();
    
                BeginParallelProcessing();
    
                //We have started 1 reader task and multiple processor tasks
                //Now we need to start a writer task that will write the cleaned lines to disk
                var finalTask = BeginWriter();
    
                //Since writer task is the task which will signify the end of the entire 
                //exercise of reading, processing and writing, we will wait till the 
                //writer task has finished too.
                Task.WaitAll(new[] {finalTask});
    
                Console.WriteLine("All text lines cleaned and written to disk.");
            }
    
            private static void BeginReader()
            {
                TaskFactory.StartNew(() =>
                {
                    Console.WriteLine("Reader task initiated.");
                    using (var reader = new StreamReader(OldFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            DirtyLines.TryAdd(line);
                        }
                        DirtyLines.CompleteAdding();
                    }
                });
            }
    
            private static void BeginParallelProcessing()
            {
                //Starting as many processor tasks as there are number of processors available
                //on this machine. These tasks will return when there are no more lines to process
    
                //Globally defined id, and a lock, for adding in the required lines.
                var globalId = 1;
                var idLock = new object();
    
                for (var taskIndex = 0; taskIndex < Environment.ProcessorCount; taskIndex++)
                {
                    TaskFactory.StartNew(() =>
                    {
                        while (!DirtyLines.IsCompleted)
                        {
                            string line, updatedLine;
                            if (!DirtyLines.TryTake(out line)) continue;
                            if (line.Contains("(''"))
                            {
                                int nextGlobalId;
                                lock (idLock)
                                {
                                    nextGlobalId = globalId++;
                                }
                                updatedLine = line.Replace("('',", "('" + nextGlobalId + "',");
                            }
                            else
                            {
                                updatedLine = line;
                            }
                            CleanLines.Add(updatedLine);
                        }
                        //Adding a delay of 10 seconds to allow all processing tasks to finish
                        Task.Delay(10*1000);
                        if (!CleanLines.IsAddingCompleted)
                        {
                            CleanLines.CompleteAdding();
                        }
                    });
                }
            }
    
            private static Task BeginWriter()
            {
                var finalTask = TaskFactory.StartNew(() =>
                {
                    Console.WriteLine("Writer task initiated.");
                    using (var writer = new StreamWriter(NewFilePath))
                    {
                        while (!CleanLines.IsCompleted)
                        {
                            string cleanLine;
                            if (!CleanLines.TryTake(out cleanLine)) continue;
                            writer.WriteLine(cleanLine);
                        }
                    }
                });
                return finalTask;
            }
        }
    }
