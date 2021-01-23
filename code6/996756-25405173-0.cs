    public async void btn_click(object s, RoutedEventArgs e)
    {
      await Task.Run(() => DoAllWork());
    }
    private async Task DoAllWork()
    {
      int[] wrk = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      var semaphore = new AsyncSemaphore(4);
      var tasks = wrk.Select(x => WorkSingleItem(x, semaphore));
      await TaskEx.WhenAll(tasks);
    }
    private async Task WorkSingleItem(int item, AsyncSemaphore semaphore)
    {
      await semaphore.WaitAsync();
      try
      {
        var response = await Request(item);
        await Handle(response);
      }
      finally
      {
        semaphore.Release();
      }
    }
