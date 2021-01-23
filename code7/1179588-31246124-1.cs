        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            var obj = App.Current as App;
            MessageBox.Show(obj.MyName);
        }
