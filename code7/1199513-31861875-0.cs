    private async void Form1_Load(object sender, EventArgs e)
    {
        dgSysproStock.IsEnabled = false;
        using (TruckServiceClient TSC = new TruckServiceClient())
        {
            var allStock = await TSC.GetSysproStockAsync();
            dgSysproStock.ItemsSource = allStock.Select(item =>
                            new AllStock
                            {
                               ...
                            }).ToArray();
            dgSysproStock.IsEnabled = true;
        }
    }
