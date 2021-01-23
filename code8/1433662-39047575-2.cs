    namespace HttpWebRequest_HighIntesive
    {
        using System;
        using System.Diagnostics;
        using System.Net;
        using System.Threading;
    
        class ThreadParam
        {
            public int RequestsCount { get; private set; }
            public CountdownEvent CountdownEvent { get; private set; }
            public ThreadParam(int requestsCount, CountdownEvent countdownEvent)
            {
                RequestsCount = requestsCount;
                CountdownEvent = countdownEvent;
            }
        }
        class FinistRequestParam
        {
            public CountdownEvent CountdownEvent { get; private set; }
            public HttpWebRequest HttpWebRequest { get; private set; }
            public FinistRequestParam(CountdownEvent countdownEvent, HttpWebRequest httpWebRequest)
            {
                CountdownEvent = countdownEvent;
                HttpWebRequest = httpWebRequest;
            }
        }
        public class Program
        {
            static Uri _uri;
            static volatile int _numberOfFinishedRequests;
            static double _prevMemoryMb = 0;
                
            public static int Main(string[] args)
            {
                int numOfRequests;
                Console.Write("Enter URL(full format, for example, http://google.ru): ");
                var url = Console.ReadLine();
                if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out _uri)){
                    Console.WriteLine("Invalid URL. Exiting"); return -1;
                }
                Console.Write("Enter number of requests: ");
                numOfRequests = Int32.Parse(Console.ReadLine());
    
                Console.WriteLine("");
                DoParallelRequests(numOfRequests);
    
                Console.WriteLine("Finished. Press 'Enter' to quit");
                Console.ReadLine();
                return 0;
            }
            private static void DoParallelRequests(int numOfRequests)
            {
                // Play with DefaultConnectionLimit
                // Increasing this value will increase speed, but also increase memory consumption
                System.Net.ServicePointManager.DefaultConnectionLimit = 350;
                Console.WriteLine("DefaultConnectionLimit: {0}", System.Net.ServicePointManager.DefaultConnectionLimit);
                int threadCnt = Environment.ProcessorCount;
                Console.WriteLine("Num of threads which creates HttpWebRequest: {0}", threadCnt);
                // Initialize CountDownEvent with numOfRequests
                CountdownEvent countDownOnTimes = new CountdownEvent(numOfRequests);
                // Create timer for statistics
                using (var timer = new Timer(TimerStatisticHanlder, Stopwatch.StartNew(), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(5)))
                {
                    // Create thread array
                    Thread[] threads = new Thread[threadCnt];
                    // Initialize each thread and start it
                    for (int i = 0; i < threads.Length; i++)
                    {
                        threads[i] = new Thread(ThreadMethod);
                        // HACK Hope numOfRequests % threadCnt == 0 (evenly divisible)
                        // Start thread
                        threads[i].Start(new ThreadParam(numOfRequests / threadCnt, countDownOnTimes));
                    }
                    // Will wait untill all request processed
                    countDownOnTimes.Wait();
                }
            }
            static void TimerStatisticHanlder(object obj)
            {
                Stopwatch sw = obj as Stopwatch;
                // Calculate average speed
                var aveageSpeed = Math.Round(_numberOfFinishedRequests / sw.Elapsed.TotalSeconds, 2);
                // Get total memory
                var totalMemoryMb = Math.Round((double)GC.GetTotalMemory(false) / 1024 / 1024);
                // Calculate memory delta
                var memoryDeltaMb = totalMemoryMb - _prevMemoryMb;
                // Print out statistics
                Console.WriteLine("{0} Processed requests: {1}, Average speed: {2} requests per/s, Used memory: {3} Mbytes, Memory delta: {4}", DateTime.Now.ToString("HH:mm:ss"), _numberOfFinishedRequests, aveageSpeed, totalMemoryMb, memoryDeltaMb);
                // Store total memory for delta calculation
                _prevMemoryMb = totalMemoryMb;
            }
            private static void ThreadMethod(object state)
            {
                var threadParam = state as ThreadParam;
                for (int i = 0; i <= threadParam.RequestsCount; i++)
                {
                    // Create HttpWebRequest
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_uri);
                    // Start it asynchronous
                    request.BeginGetResponse(new AsyncCallback(FinishRequest), new FinistRequestParam(threadParam.CountdownEvent, request));
                }
            }
            private static void FinishRequest(IAsyncResult result)
            {
                var reqParam = result.AsyncState as FinistRequestParam;
                var request = reqParam.HttpWebRequest;
                try
                {
                    // Just end response
                    HttpWebResponse response = request.EndGetResponse(result) as HttpWebResponse;
                    // Release all resources
                    response.GetResponseStream().Dispose();
                    response.Close();
                    (request as IDisposable).Dispose();
                }
                catch { } // Don't care about exceptions
    
                // Mark yet another request finished
                reqParam.CountdownEvent.Signal();
                // Increment total number of finished requests
                Interlocked.Increment(ref _numberOfFinishedRequests);
            }
        }
    }
