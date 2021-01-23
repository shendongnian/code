    private async void button_Click(object sender, RoutedEventArgs e)
    {
         lblStatus.Content = "Loading...";
         string price = await GetBitcoinPrice();
         txtResult.Text = price;
         lblStatus.Content = "Done";
                
    }
