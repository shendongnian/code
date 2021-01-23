    public static async void TaskDoWork()
    {
       using (var dispose = new TaskDispose())
       {
           await dispose.RunAsync();
       }
    }
    public class TaskDispose : IDisposable
    {
       public async Task RunAsync()
       {
           await Task.Delay(3000);
       }
    }
