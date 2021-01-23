    private async void OnGoButtonClick(object sender, EventArgs e)
    {
      await Task.WhenAll(_listBox.Items.OfType<string>() 
          .Select(taskArgument => ProcessAsync(taskArgument)));
    }
    private async Task ProcessAsync(string taskArgument)
    {
      var result = await Task.Run(() => DoLongTermApplication(taskArgument));
      _listBox.Items[_listBox.Items.IndexOf(taskArgument)] = result;
    }
    private string DoLongTermApplication(string taskInformation)
    {
      Thread.Sleep(1000 + _random.Next(1000));
      return $"Processed {taskInformation}";
    }
