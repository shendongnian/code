    private Network networkService = new Network();
    ...
    // Somewhere in initialization code:
    networkService.NewDevice += (sender, device) => Dispatcher.Invoke(() => viewModel.DevicesCollection.Add(device) );
    ...
    private void ScanButton_OnClick(object sender, RoutedEventArgs e)
    {
        viewModel.DevicesCollection.Clear();
        networkService.StartScan();
    }
