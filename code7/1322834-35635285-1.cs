    private async void OnGoButtonClick(object sender, EventArgs e)
    {
      await Task.WhenAll(_listBox.Items.OfType<string>() 
          .Select(taskArgument => ProcessAsync(taskArgument)));
    }
    private async Task ProcessAsync(string taskArgument)
    {
      var result = await DoLongTermApplicationAsync(taskArgument);
      _listBox.Items[_listBox.Items.IndexOf(taskArgument)] = result;
    }
    private async Task<string> DoLongTermApplicationAsync(string taskInformation)
    {
      await Task.Delay(1000 + _random.Next(1000)).ConfigureAwait(false);
      return $"Processed {taskInformation}";
    }
