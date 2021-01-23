    private async void BtnClickEvent(object sender, RoutedEventArgs e)
    {
        try
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
            DoSomethingElse();
         }
         catch(Exception ex)
         {
         }
    }
  
