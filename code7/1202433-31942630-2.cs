    async void Button1_Click(object sender, RoutedEventArgs e)
    {
        progressBar1.IsIndeterminate = true;
        try
        {
            await Task.Factory.StartNew(() =>
            {
               scrape();
            });
        }
        catch(AggregateException ae)
        {}
        finally
        {
             progressBar1.IsIndeterminate = false;
        }
    }
    
