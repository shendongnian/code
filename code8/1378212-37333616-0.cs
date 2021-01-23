    public async Task<int> GetInteger()
    {
      container.Controls.Clear();
      container.Controls.Add(integerInput); 
      // Note: not `Result`, which will wrap exceptions.
      return await integerInput.InputVal.Task;
    }
    public async Task MethodToInvokeAsync()
    {
      await Task.Run(...); // Interface with hardware...
      // Block waiting on input
      int val = await ui.GetInteger(); 
      await Task.Run(...); // Interface with hardware some more...
    }
    var t = await (Task)method.Invoke(DemoInstance, args);
