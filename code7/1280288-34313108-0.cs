    public async void button1_clicked(object sender, ...)
    {
        Task<int> task1 = this.DoSomethingAsync(...);
        // while task1 is running you can do other things
        // you can even schedule another task:
        Task task2 = this.DoSomethingElseAsync(...);
        // do other things. After a while you need the result of task1:
        int task1Result = await task1;
        // or if you want to await until both tasks are finished:
        await Task.WhenAll(new Task[]{task1, task2});
        int task1Result = task1.Result;
    }
    private async Task<int> DoSomethingAsync(...)
    {
         // schedule another async task and await:
         await DoSomethingElseAsync(...);
         return 42;
    }
    private async Task DoSomethingElseAsync(...)
    {
        // do something really important:
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
    }
