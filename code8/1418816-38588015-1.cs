    async void btnTest_Click(object sender, EventArgs e)
    {
      DoSomethingAsync().Result;
    }
    async Task DoSomethingAsync()
    {
      await Task.Delay(1000);
    }
