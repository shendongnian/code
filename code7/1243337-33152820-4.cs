    public void StoreDataTest()
    {
      AsyncContext.Run(() => MainClass.Start());
      var data = UtilityClass.GetStoredData();
      Assert.IsNotNull(data, "No data found");
    }
