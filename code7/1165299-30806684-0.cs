        private void EventSetter_OnHandlerSelected(object sender, RoutedEventArgs e)
        {
            DataGridRow dgr = FindParent<DataGridRow>(sender as DataGridCell);
            dgr.Background = new SolidColorBrush(Colors.Red);
        }
        private void EventSetter_OnHandlerLostFocus(object sender, RoutedEventArgs e)
        {
            DataGridRow dgr = FindParent<DataGridRow>(sender as DataGridCell);
            dgr.Background = new SolidColorBrush(Colors.White);
        }
