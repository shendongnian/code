    private async void GetData_Click(object sender, RoutedEventArgs e)
    {
        RootObject nycParking = await BPNewYorkCityProxy.GetNewYorkCity();
        // how to get a stationname .. my proxy creates a list, does it?... 
        stations.ItemsSource = nycParking.stationBeanList;
        // Well this works
        myTimeStamp.Text = nycParking.executionTime.ToString();
    }
