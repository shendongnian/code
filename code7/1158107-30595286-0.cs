    public async Task ExecuteAsync(object parameter)
    {
      if (IsBusy)
        return;
      IsBusy = true;
      var asyncCommand = backingCommand as IAsyncCommand;
      if (asyncCommand != null)
        await asyncCommand.ExecuteAsync(parameter);
      else
        backingCommand.Execute(parameter);
      IsBusy = false;
    }
