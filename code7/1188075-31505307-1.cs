        private void SearchButtonActions() {
            lblWait.Visibility = Visibility.Visible;
            Task.Run(() => {
                return FD.Search(index, selecteditem);
            }).ContinueWith((Task<bool> task) => {
                Dispatcher.Invoke(() => FDItems = new ObservableCollection<Item>(FD.Items));
                lblWait.Visibility = Visibility.Hidden;
            });
    	}
