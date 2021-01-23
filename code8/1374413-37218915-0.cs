    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    namespace LockTraceParser
    {
      internal class AsyncThreadsTester
      {
        public void Run()
        {
          //ThreadPool.SetMinThreads(100, 100);
          Console.WriteLine("Beginning Test: ");
          LogThreadCounts();
          Test();
        }
        private void Test()
        {
          LogThreadCounts();
          for (int i = 0; i < 65; i++)
          {
            //StartParallelUserWorkItem(i);
            StartTask(i);
            Thread.Sleep(100); //sleep a while so that the other thread is working
            LogThreadCounts();
          }
          for (int i = 0; i < 40; i++)
          {
            Thread.Sleep(1100); //sleep a while so that the other thread is working
            LogThreadCounts();
          }
        }
        private void StartTask(int label)
        {
          var taskLabel = "Task " + label;
          Console.WriteLine("Enqueue " + taskLabel);
          Task.Run(() => GetResponseAwait(taskLabel));
        }
        private static void LogThreadCounts()
        {
          int worker;
          int io;
          ThreadPool.GetAvailableThreads(out worker, out io);
          Console.WriteLine("Worker Threads Available:" + '\t' + worker + '\t' + "IO Threads Available:" + '\t' + io + '\t' +
                            "Threads held by Process: " + '\t' + Process.GetCurrentProcess().Threads.Count);
        }
        private void GetResponseSync(object label)
        {
          Console.WriteLine("Start Sync     " + label);
          try
          {
            var req = GetRequest();
            using (var resp = req.GetResponse())
            {
              Console.WriteLine(resp.ContentLength);
            }
          }
          catch (Exception e)
          {
            Console.WriteLine("Error response " + label);
          }
          Console.WriteLine("End response   " + label);
        }
        private void BeginResponseAsync(object label)
        {
          Console.WriteLine("Start Async     " + label);
          try
          {
            var req = GetRequest();
            req.BeginGetResponse(EndGetResponseAsync, req);
          }
          catch (Exception e)
          {
            Console.WriteLine("Error Async " + label);
          }
        }
        private void EndGetResponseAsync(IAsyncResult result)
        {
          Console.WriteLine("Respond Async   ");
          var req = (WebRequest)result.AsyncState;
          using (var resp = req.EndGetResponse(result))
          {
            Console.WriteLine(resp.ContentLength);
          }
          Console.WriteLine("End Async   ");
        }
        private async Task GetResponseAwait(object label)
        {
          Console.WriteLine("Start Await     " + label);
          try
          {
            var req = GetRequest();
            using (var resp = await req.GetResponseAsync())
            {
              Console.WriteLine(resp.ContentLength);
            }
          }
          catch (Exception e)
          {
            Console.WriteLine("Error Await " + label);
          }
          Console.WriteLine("End Await   " + label);
        }
        private WebRequest GetRequest()
        {
          var req = WebRequest.Create("http://aslowwebsite.com");
          req.Timeout = (int)TimeSpan.FromSeconds(60).TotalMilliseconds;
          return req;
        }
      }
    }
