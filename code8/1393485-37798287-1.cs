    private void GetInformation(object sender, SelectionChangedEventArgs e)
    {
        ComboBox currentItem = sender as ComboBox;
        int driverKey = Convert.ToInt32(currentItem.SelectedValue);
        DriverData driver = new DriverData();  //What's this for?
        driver.SetDriverData(driverKey); //What's this for?
        int years = driver.ServiceYears; //What's this for?
        var startDate=new DateTime(2016, 5, 2);
        var endDate=new DateTime(2016, 5, 8);
        var items = transportationDb._Payroll_Orders
          .Where(o=>o.Ord_Driver_Key == driverKey)
          .Where(o=>o.Delivery_Date >= startDate && o.Delivery_Date <= endDate)
          .Select(o=>new SalesItem {
            DriverName=o.Driver_Name,
            ...
          });
        dataGrid.ItemsSource = items;
    }
