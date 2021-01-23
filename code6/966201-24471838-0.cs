    using (IsolatedStorageFileStream fileStream = IsolatedStorageFile.GetUserStoreForApplication().CreateFile(data.SavePath))
    {                    
        if (args == null || args.Cancelled || args.Error != null)
        {
            MessageBox.Show("No connection");
            return;
        }
        args.Result.Seek(0, SeekOrigin.Begin);
        args.Result.CopyTo(fileStream);
        AudioPlayer.SetSource(fileStream);
        AudioPlayer.Play();
    }
