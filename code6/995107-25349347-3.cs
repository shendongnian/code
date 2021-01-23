    private async void WritePath(object sender, PostProcessingEventArgs e)
    {
      using (e.GetDeferral())
      {
        await Task.Delay(1000);
        Debug.WriteLine(e.CachedPath);
      }
    }
