        private async Task<string> SimLongRunningProcessAsync()
        {
            await Task.Delay(2000);
            return "Success";
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            button.Content = "Running...";
            var result = await SimLongRunningProcessAsync();
            button.Content = result;
        }
