    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
                Logger.LogFile = @"c:\temp\test\log.txt";
    
                Task.Run(async () =>
                {
                    // two instances (not disposed properly)
    
                    // if left to run, this background task keeps running until the application exits
                    var c1 = new MyClassWithVolatileBoolCancellationFlag();
    
                    // if left to run, this background task cancels correctly
                    var c2 = new MyClassWithCancellationSourceAndNoLambda();
    
                    Logger.Log("Pausing");
                        await Task.Delay(5000);
                        Logger.Log("Finished Pausing");
    
                }).GetAwaiter().GetResult();
    
                // instances no longer referenced at this point
    
                Logger.Log("Press Enter to exit");
                Console.ReadLine(); // press enter to allow the console app to exit normally: finalizer gets called on both instances
            }
    
    
            static class Logger
            {
                private static object LogLock = new object();
                public static string LogFile;
                public static void Log(string toLog)
                {
                    try
                    {
                        lock (LogLock)
                            using (var f = File.AppendText(LogFile))
                                f.WriteLine(toLog);
    
                        Console.WriteLine(toLog);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Logging Exception: " + ex.ToString());
                    }
                }
    
            }
    
    
            public class MyClassWithCancellationSourceAndNoLambda : IDisposable
            {
                private CancellationTokenSource cts = new CancellationTokenSource();
    
                private readonly Task feedTask;
    
                public MyClassWithCancellationSourceAndNoLambda()
                {
                    Logger.Log("New MyClassWithCancellationSourceAndNoLambda Instance");
                    feedTask = Task.Factory.StartNew(Background, cts.Token);
                }
    
                private static void Background(object state)
                {
                    var cancelled = (CancellationToken)state;
                    if (cancelled != null)
                    {
                        int i = 0;
                        while (!cancelled.IsCancellationRequested)
                        {
                            Logger.Log("Background task for MyClassWithCancellationSourceAndNoLambda running. " + i++);
                            Thread.Sleep(1000);
                        }
                    }
                }
    
                public void Dispose()
                {
                    Dispose(true);
                    GC.SuppressFinalize(this);
                }
    
                protected virtual void Dispose(bool disposing)
                {
                    cts.Cancel();
    
                    if (disposing)
                    {
                        feedTask.Wait();
    
                        feedTask.Dispose();
    
                        Logger.Log("MyClassWithCancellationSource Disposed");
                    }
                    else
                    {
                        Logger.Log("MyClassWithCancellationSource Finalized");
                    }
                }
    
                ~MyClassWithCancellationSourceAndNoLambda()
                {
                    Dispose(false);
                }
            }
    
    
    
            public class MyClassWithVolatileBoolCancellationFlag : IDisposable
            {
                class CancellationFlag { public volatile bool IsSet; }
    
                private CancellationFlag cf = new CancellationFlag();
    
                private readonly Task feedTask;
    
                public MyClassWithVolatileBoolCancellationFlag()
                {
                    Logger.Log("New MyClassWithVolatileBoolCancellationFlag Instance");
                    feedTask = Task.Factory.StartNew(() =>
                    {
                        int i = 0;
                        while (!cf.IsSet)
                        {
                            Logger.Log("Background task for MyClassWithVolatileBoolCancellationFlag running. " + i++);
                            Thread.Sleep(1000);
                        }
                    });
                }
    
    
                public void Dispose()
                {
                    Dispose(true);
                    GC.SuppressFinalize(this);
                }
    
                protected virtual void Dispose(bool disposing)
                {
                    cf.IsSet = true;
    
                    if (disposing)
                    {
                        feedTask.Wait();
    
                        feedTask.Dispose();
    
                        Logger.Log("MyClassWithVolatileBoolCancellationFlag Disposed");
                    }
                    else
                    {
                        Logger.Log("MyClassWithVolatileBoolCancellationFlag Finalized");
                    }
                }
    
                ~MyClassWithVolatileBoolCancellationFlag()
                {
                    Dispose(false);
                }
            }
        }
    }
