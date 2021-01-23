    private async void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
      // ** On the UI thread **
      Console.WriteLine("Caller threadId = " + Thread.CurrentThread.ManagedThreadId);
      await DoNothingAsync();
      // ** On the UI thread **
    }
    private async Task DoNothingAsync()
    {
      // ** On the UI thread **
      Console.WriteLine("working asynchronously on thread: " + Thread.CurrentThread.ManagedThreadId);
      await Task.Delay(5); // Task.Delay is the asynchronous version of Thread.Sleep
      // ** On the UI thread **
    }
