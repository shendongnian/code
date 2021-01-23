        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var res = Xceed.Wpf.Toolkit.MessageBox.Show(
                               "R U sure?",
                               "Confirm dialog",
                               MessageBoxButton.YesNoCancel,
                               MessageBoxImage.None,
                               MessageBoxResult.Cancel,
                               (Style)Resources["MessageBoxStyle1"]
                           );
            if ("Cancel" == res.ToString())
            {
            }
            else if ("No" == res.ToString())
            {
            }
            else if ("Yes" == res.ToString())
            {
            }
            else
            {
            }
        }
