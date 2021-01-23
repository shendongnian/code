    public async void Loaded()
    {
      MerchantsLoading = true;
      Merchants = await Task.Run(() => SQLite.GetMerchants());
      MerchantsLoading = false;
    }
