    private void yellowBox_Click(object sender, RoutedEventArgs e) {
        yellowBox.Margin = new Thickness(185, 61, 0, 0);
        Task.Factory.StartNew(() => {
            Thread.Sleep(1000);
            yellowBox.Dispatcher.Invoke((Action)(() => {
                yellowBox.Margin = new Thickness(0);
            }));
            yellowBox.Margin = new Thickness(0);
        });
    }
