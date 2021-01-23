    public class SequencedRequestsDemo
    {
        private class SampleRequest
        {
            public string ActionName { get; set; }
            public UserCredential UserCredential { get; set; }
        }
        private class UserCredential
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        private ConcurrentQueue<SampleRequest> _queue = new ConcurrentQueue<SampleRequest>();
        public override void Run()
        {
            _queue.Enqueue(new SampleRequest { ActionName = "action_name1", UserCredential = new UserCredential() });
            _queue.Enqueue(new SampleRequest { ActionName = "action_name2", UserCredential = new UserCredential() });
            _queue.Enqueue(new SampleRequest { ActionName = "action_name3", UserCredential = new UserCredential() });
            _queue.Enqueue(new SampleRequest { ActionName = "action_name4", UserCredential = new UserCredential() });
            _queue.Enqueue(new SampleRequest { ActionName = "action_name5", UserCredential = new UserCredential() });
            _queue.Enqueue(new SampleRequest { ActionName = "action_name6", UserCredential = new UserCredential() });
            var thread1 = new System.Threading.Thread(() => {
                WaitForRequest();
            });
            var thread2 = new System.Threading.Thread(() => {
                WaitForRequest();
            });
            var thread3 = new System.Threading.Thread(() => {
                WaitForRequest();
            });
            thread1.Start();
            thread2.Start();
            thread3.Start();
        }
        private void WaitForRequest()
        {
            while(true)
            {
                SampleRequest request;
                if (_queue.TryDequeue(out request))
                {
                    HandleRequest(request);
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        private void HandleRequest(SampleRequest request)
        {
            Console.WriteLine("Handle request {0} - {1}", request.ActionName, System.Threading.Thread.CurrentThread.ManagedThreadId);
        }
    }
