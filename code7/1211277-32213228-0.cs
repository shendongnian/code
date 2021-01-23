        var pictureURL = "ms-appx:///Assets/folder/Picture.jpg";
        StorageFile storageFile = await KnownFolders.SavedPictures.CreateFileAsync("Picture.jpg", CreationCollisionOption.GenerateUniqueName);
        StorageFile pictureFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(pictureURL));
        using (var imageFile = await pictureFile.OpenStreamForReadAsync())
        {
            using (var imageDestination = await storageFile.OpenStreamForWriteAsync())
            {
                 await imageFile.CopyToAsync(imageDestination);
            }
        }
        ImageProperties imageProperties = await storageFile.Properties.GetImagePropertiesAsync();
        imageProperties.DateTaken = DateTime.Now;
        imageProperties.CameraManufacturer = "";
        imageProperties.CameraModel = "";
        await imageProperties.SavePropertiesAsync();
