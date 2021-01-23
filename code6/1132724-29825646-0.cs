    [TestFixture]
    public class FIXTURENAMETests {
      [Test]
      public async Task NAME() {
        var tcs = new TaskCompletionSource<bool>();
        Task t = LongRunningStuff(tcs);
        if (CanInsertInDictionary(t)) {
          tcs.SetResult(true);
        } else {
          tcs.SetException(new Exception());
        }
        Trace.WriteLine("waiting for end");
  
        try {
          await t;
        }
        catch (Exception exception) {
          Trace.WriteLine(exception);
        }
  
        Trace.WriteLine("end all");
      }
  
      private bool CanInsertInDictionary(Task task) {
        return true;
      }
      private async Task LongRunningStuff(TaskCompletionSource<bool> tcs) {
        Trace.WriteLine("start");
        try {
          await tcs.Task;
        }
        catch (Exception) {
          return;
        }
        Trace.WriteLine("do long running stuff");
        await Task.Delay(10000);
        Trace.WriteLine("end");
      }
    }
