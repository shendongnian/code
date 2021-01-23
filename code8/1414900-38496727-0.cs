    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var oneDriveClient = await OneDriveClientExtensions.GetAuthenticatedUniversalClient(new[] { "onedrive.appfolder" });
    
        using (var contentStream = new MemoryStream(Encoding.UTF8.GetBytes(textBox.Text)))
        {
            var item = await oneDriveClient.Drive.Special.AppRoot.ItemWithPath("backup.txt").Content.Request().PutAsync<Item>(contentStream);
        }
    }
