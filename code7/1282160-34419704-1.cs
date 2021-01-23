    public async void Button1_Clicked(object Sender, ...)
    {
        var task = MySlowMultiplier(3, 4);
        // while task running you can do other things
        // the UI remains responsive
        // after a while:
        int result = await task;
        ProcessResult(result);
     }
     private async Task<int> MySlowMultiplier(int x, int y)
     {
         // I'm really slow:
         await Task.Delay(TimeSpan.FromSeconds(5));
         return x * y;
     }
      
