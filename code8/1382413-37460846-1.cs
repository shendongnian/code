    private async void ButtonStartSomething_Click()
    {
      ButtonStartSomething.Enabled = false;
      await LongRunningTaskAsync();
      ButtonStartSomething.Enabled = true;
    }
    private async Task LongRunningTaskAsync()
    {
      // Initialize
      await Task.Delay(10000);
      // Clean up
    }
