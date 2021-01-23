    Task _filterWorker;
    private void RunFilterWorker()
    {
      if (_filterWorker == null)
      {
        _filterWorker = FilterAsync();
      }
    }
    private Task FilterAsync()
    {
      PanelLoading = true;
      try
      {
        Products = await FilterProducts();
      }
      catch (Exception ex)
      {
        LogHelper.Log(ex);
      }
      PanelLoading = false;
      // Ensure the calling method has set _filterWorker before we clear it.
      await Task.Yield();
      _filterWorker = null;
    }
