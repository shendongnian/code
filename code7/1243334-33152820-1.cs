    public async Task StoreDataTest()
    {
      await MainClass.StartAsync();
      var data = UtilityClass.GetStoredData();
      Assert.IsNotNull(data, "No data found");
    }
