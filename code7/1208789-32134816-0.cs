    public class CSharpClass
    {
        public async void AwaitSomething()
        {
            var task = new VbNetClass().DoSomething();
            await task;
            // test task.Result for null
            var result = (task.Result ?? "method was unsuccessful").ToString();
    
            // rest of code follows
        }
    }
