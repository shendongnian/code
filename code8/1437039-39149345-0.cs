    private async void GetData_Click(object sender, RoutedEventArgs e)
    {
        RootObject nycParking = await BPNewYorkCityProxy.GetNewYorkCity();
        foreach (var station in nycParking.stationBeanList)
        {
            // Access all of them here may be?
            Console.WriteLine(station.stationName);
        } 
        // Well this works
        myTimeStamp.Text = nycParking.executionTime.ToString();
    }
