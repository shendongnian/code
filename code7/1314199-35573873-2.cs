    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        _context.Suppliers.Load();
        _context.Categories.Load();
        _context.Devices.Load();
        var devices = _context.Devices.GetLocal();
        DeviceListDataGrid.ItemsSource = devices;
        ICollectionViewLiveShaping deviceView =
            (ICollectionViewLiveShaping) CollectionViewSource.GetDefaultView(devices);
        deviceView.IsLiveSorting = true;
        ProductCategoryComboBox.ItemsSource = (System.Collections.IEnumerable) deviceView;
        SupplierComboBox.ItemsSource = _context.Suppliers.GetLocal();
    }
