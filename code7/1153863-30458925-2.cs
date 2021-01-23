    public class Sample
    {
        public async void RunSample() 
        {
            // return a task. later obtain a result if some fashion 
            Task<bool> task = DoSomethingAsync();
            bool res1 = task.Result;
            
            // await a task which is created for you by re-wrapping the result.
            bool res2 = await AwaitSomethingAsync();
            // await a task which is created for you by rewrapping the result due to await.
            bool res3 = await DoSomethingAsync2();
            // await a task.
            bool res4 = await DoSomethingAsync();     
        }
        
        public async Task<bool> DoSomethingAsync2()
        {
            return false;
        }
        public Task<bool> DoSomethingAsync()
        {
            return Task<bool>.Run(() => { return false; });
        }
        public async Task<bool> AwaitSomethingAsync()
        {
            bool res = await Task<bool>.Run(() => { return false; });
            return res; // re-wraps it in a Task
        }
    }
 
