    private async void BtnClickEvent(object sender, RoutedEventArgs e)
    {
        try
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
            DoSomethingElse();
         }
         catch(Exception ex)
         {
         }
    }
  
