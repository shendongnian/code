        private void myHeavyProcess()
        {
            ObservableCollection<object> data = new ObservableCollection<object>();
            //....
            //prepare data 
            //...
            grdCharts.Dispatcher.BeginInvoke(
                (Action<IEnumerable>)(d => grdCharts.Children.Add(new DataGrid() { ItemsSource = d })), 
                DispatcherPriority.Background, 
                new object[] { data });
        }
