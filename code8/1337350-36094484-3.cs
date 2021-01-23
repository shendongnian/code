    private async void button_Click(object sender, RoutedEventArgs e)
    {
         lblStatus.Content = "Loading...";
         string result = await GetBitcoinPrice();
         txtResult.Text = price;
         lblStatus.Content = "Done";
                
    }
