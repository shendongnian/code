    // Initial dummy task.
    private Task taskChain = Task.FromResult(true);
    // Chain dynamically on button click.
    private async void DoSth_Click(object sender, RoutedEventArgs e)
    {
      var data = ....;
      taskChain = ChainedConvertAsync(taskChain, data);
      var res = await taskChain;
      ...
    }
    private async Task<Result> ChainedConvertAsync(Task precedent, Data data)
    {
      await precedent;
      return await ConvertAsync(data);
    }
