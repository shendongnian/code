    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter != null)
        {
            var data = e.Parameter;
            txtMessages.Text = data.ToString();
        }
    }
