    private async void startButton_Click(object sender, RoutedEventArgs e)
    {
      await GetWebDataAsync("http://localhost:801/"); //starting url
    }
    private async Task GetWebDataAsync(string url) {
      var urls = ...;
      var urlTasks = urls.Select(s => GetWebDataAsync(s));
      await Task.WhenAll(urlTasks);
    }
