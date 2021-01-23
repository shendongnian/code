        private async Task<string> SimLongRunningProcessAsync()
        {
            Thread.Sleep(2000);
            return "Success";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = await SimLongRunningProcess();
            button.Content = result;
        }
