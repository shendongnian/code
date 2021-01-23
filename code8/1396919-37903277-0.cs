        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var bookmark = new Bookmark();
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile createFile = await storageFolder.CreateFileAsync("bookmark.xml", CreationCollisionOption.ReplaceExisting);
            bookmark.Button = cmbButton.SelectedIndex;
            bookmark.Name = txtName.Text;
            bookmark.URL = txtURL.Text;
            var output = SerializeToXml(bookmark);
            StorageFile sampleFile = await storageFolder.GetFileAsync("bookmark.xml");
            await FileIO.WriteTextAsync(sampleFile, output);   
        }
