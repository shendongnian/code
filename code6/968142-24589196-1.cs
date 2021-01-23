        private void OtherPageCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var page = ((Frame)((TabItem) TabControl.SelectedItem).Content).Content as OtherPage;
            if (page != null)
            {
                var viewModel = page.DataContext as MyViewModel;
                if (viewModel != null)
                {
                    var openWindow = viewModel.MyCommand;
                    var parameter = null; // put your command parameter here
                    if (openWindow.CanExecute(parameter))
                        openWindow.Execute(parameter);
                }
            }
        }
