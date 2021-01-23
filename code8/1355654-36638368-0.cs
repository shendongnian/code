        private async void BtnConnectWcf_Click(object sender, RoutedEventArgs e)
        {
            ToDoService.Service1Client client = new ToDoService.Service1Client();       
            await new Windows.UI.Popups.MessageDialog(client.GetDataAsync(10).Result.ToString()).ShowAsync();
            await client.CloseAsync();
        }
