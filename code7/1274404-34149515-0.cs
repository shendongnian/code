     async public void AddFileCall(Windows.ApplicationModel.Activation.FileActivatedEventArgs e)
        {
            StorageFolder magazinefolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(Constants.MagFolder, CreationCollisionOption.OpenIfExists);
            foreach (StorageFile file in e.Files)
            {
                await file.CopyAsync(magazinefolder,file.Name,NameCollisionOption.GenerateUniqueName);
            }
            MessageDialog Sucess = new MessageDialog("File Imported", "Thank You");
            await Sucess.ShowAsync();
            this.loadlibrary();
        }
