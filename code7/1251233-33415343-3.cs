    private async void _btnTruck_OnClick(object sender, RoutedEventArgs e)
        {
    int count = 0;
            try
            {
                count = await Task.Run(() => LoadData(), CancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
               _log.Error(ex); 
            }
    }
