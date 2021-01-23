    try
    {
        news c = news_List.SelectedItem as news;
        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => this.Frame.Navigate(typeof(Pages.newsItem), c));
    }
    catch(Exception ex)
    {
        MessageDialog j = new MessageDialog(ex.Message);
        await j.ShowAsync();
    }
