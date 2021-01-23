    private async void BtnClickEvent(object sender, RoutedEventArgs e)
    {
      await Task.Run(() =>
            {
                try
                {
                   DoSomeWork();
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            });
    }
