    private async void btn_Click(object sender, RoutedEventArgs e)
    {
        Info info = await GetInfoAsync("en-US");
        textInfo.Text = info.Value
    }
    private Task<Info> GetInfoAsync(string culture)
    {
        InfoSoapClient client = new InfoSoapClient();
        return client.GetInfoAsync(culture);
    }
