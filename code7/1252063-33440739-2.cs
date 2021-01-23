    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using Timer = System.Timers.Timer;
    namespace ThreadSync2
    {
        static class Measurement
        {
            private static readonly Random rng = new Random();
            private static long Evaluate(string methodName, Action signal, Action wait)
            {
                var isProducing = false;
                var isConsuming = false;
                var mtxData     = new object(); 
                var data        = new Queue<Tuple<long,int>>();
                var produced    = 0L;
                var consumed    = 0L;
                var watch       = new Stopwatch();
                var producer = new Thread(() => 
                {
                    Debug.WriteLine("Production : started.");
                    while (isProducing)
                    {
                        var item = rng.Next(0, 100);
                        
                        lock (mtxData)
                            data.Enqueue(new Tuple<long, int>(produced, item));
                        
                        signal();
                        Debug.WriteLine($"{watch.Elapsed.Seconds,3:d}.{watch.Elapsed.Milliseconds:d3} Producer: {produced,6:d} [{item,3:d}]");
                        ++produced;
                    }
                    Debug.WriteLine("Production : finished.");
                }){Name = "Producer"};
                var consumer = new Thread(() => 
                {
                    Debug.WriteLine("Consumption: started.");
                    while (   (isConsuming)
                           || (data.Count > 0))
                    {
                        while (data.Count > 0)
                        {
                            Tuple<long, int> record;
                            lock (mtxData)
                                record = data.Dequeue();
                            Debug.WriteLine($"{watch.Elapsed.Seconds,3:d}.{watch.Elapsed.Milliseconds:d3} Consumer: {record.Item1,6:d} [{record.Item2,3:d}]");
                            ++consumed;
                        }
                        
                        wait();
                    }
                    Debug.WriteLine("Consumption: finished.");
                }){Name = "Consumer"};
                var timer = new Timer(5000){AutoReset = false};
                timer.Elapsed += (s, e) => {isProducing = false;};
                Console.WriteLine($"Evaluating \"{methodName}\"...");
                watch.Start();
                timer.Enabled = true;
                isConsuming = true;
                isProducing = true;
                consumer.Start();
                producer.Start();            
                producer.Join();
                isConsuming = false;
                consumer.Join();
                watch.Stop();
                Console.WriteLine($"Produced items: {produced:### ### ##0}{((produced != consumed) ? $", Consumed items: {consumed:### ### ##0}" : "")}");
                Console.WriteLine();
                return produced;
            }
            public static void Evaluate()
            {
                const string strMonitorLock = "Monitor locking";
                const string strWaitHandle  = "AutoResetEvent";
                const int    waitTimeout    = 500;
                var semMonitorLock = new object();
                var semWaitHandle  = new AutoResetEvent(false);
                var cntMonitorLock = Evaluate
                (
                    strMonitorLock,
                    () => {lock (semMonitorLock) Monitor.Pulse(semMonitorLock);},
                    () => {lock (semMonitorLock) Monitor.Wait (semMonitorLock, waitTimeout);}
                );
                var cntWaitHandle = Evaluate
                (
                    strWaitHandle,
                    () => semWaitHandle.Set(),
                    () => semWaitHandle.WaitOne(waitTimeout)
                );
                Console.WriteLine($"{strMonitorLock} / {strWaitHandle} = {((double)cntMonitorLock / cntWaitHandle):0.000}");
                Console.WriteLine();
            }
        }
        class Program
        {
            static Program()
            {
                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            }
            static void Main(string[] args)
            {
                Measurement.Evaluate();
            }
        }
    }
