    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main()
        {
            var ad = AppDomain.CreateDomain("WhereTheWorkHappens");
    
            Task<string> t = DoWorkInOtherDomain(ad);
            Console.WriteLine("waiting...");
            Console.WriteLine(t.Result);
    
            Console.ReadLine();
        }
    
        static Task<string> DoWorkInOtherDomain(AppDomain ad)
        {
            var ch = new MarshaledResultSetter<string>();
    
            Worker worker = (Worker)ad.CreateInstanceAndUnwrap(typeof(Worker).Assembly.FullName, typeof(Worker).FullName);
            worker.DoWork(ch);
    
            return ch.Task;
        }
    
        class Worker : MarshalByRefObject
        {
            public void DoWork(MarshaledResultSetter<string> callback)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    Thread.SpinWait(500000000);
                    callback.SetResult(AppDomain.CurrentDomain.FriendlyName);
                });
            }
        }
    
        class MarshaledResultSetter<T> : MarshalByRefObject
        {
            private TaskCompletionSource<T> m_tcs = new TaskCompletionSource<T>();
            public void SetResult(T result) { m_tcs.SetResult(result); }
            public Task<T> Task { get { return m_tcs.Task; } }
        }
    }
