C#
static async Task DoSomething(int n);
static void RunConcurrently(int total, int throttle) 
{
  var mutex = new SemaphoreSlim(throttle);
  var tasks = Enumerable.Range(0, total).Select(async item =>
  {
    await mutex.WaitAsync();
    try { DoSomething(item); }
    finally { mutex.Release(); }
  });
  Task.WhenAll(tasks).Wait();
}
