    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation)
        {
            var shareOperation = (Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation)e.Parameter;
            if (shareOperation.Data.Contains(Windows.ApplicationModel.DataTransfer.StandardDataFormats.Text))
            {
                var data = await shareOperation.Data.GetTextAsync();
                ((Frame)splitView.Content).Navigate(typeof(WorkPage), data);
            }
        }
        else
        {
            ((Frame)splitView.Content).Navigate(typeof(WorkPage));
        }
    }
