    this.Dispatcher.Invoke((Action)(() =>
    {
        dgSysproStock.ItemsSource = (allStock.ToArray());
        dgSysproStock.IsEnabled = true;
    }));
