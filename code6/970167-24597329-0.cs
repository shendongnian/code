    private async Task<StorageFile> GetCsvFile()
        {
            var localFolder =  Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = await localFolder.CreateFileAsync("NRBcatalogue.csv", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            String rk = "tanujsharma59";
            await Windows.Storage.FileIO.WriteTextAsync(file, rk);
            return file;
        }
        private async Task AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            EmailMessage email = new EmailMessage();
            email.To.Add(new EmailRecipient("tanujsharma59@gmail.com"));
            email.Subject = "NRB Catalogue";
            var file = await GetCsvFile(); //Error occured here
            email.Attachments.Add(new EmailAttachment(file.Name, file));
            await EmailManager.ShowComposeNewEmailAsync(email);
        }
