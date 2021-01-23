    private async void BtnClickEvent(object sender, RoutedEventArgs e)
    {
      await Task.Run(() =>
            {
                try
                {
                    throw new NullReferenceException();
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            });
    }
