    private async void button_Click(object sender, RoutedEventArgs e)
    {
         lblStatus.Content = "Loading...";
         int bitcoinPriceTask = await GetBitcoinPrice();
         lblStatus.Content = "Done";
            
    }
    
    protected async Task<int> GetBitcoinPrice()
    {
         IPriceRetrieve bitcoin = new BitcoinPrice();
         string price = await bitcoin.GetStringPrice();
         txtResult.Text = price;
         return 1;
    }
