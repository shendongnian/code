        public void MethodOne()
        {
            MethodTwo()
                .ContinueWith(task =>
                {
                    if (task.IsFaulted)
                        // Handle error in task.Exception
                        ;
                    else
                    {
                        object obj = task.Result;
                        // Handle object
                    }
                });
        }
        public Task<object> MethodTwo()
        {
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            //Conduct async call to external server 
            AppServer.MakeCall(response =>
            {
                if (Response.IsValid)
                    tcs.TrySetResult(response.Object);
                else
                    tcs.TrySetException(new FooException());
            });
            return tcs.Task;
        }
