        if (imageReceived != null)
        {
            using (var imageStream = await imageReceived.OpenReadAsync())
            {
                var fileSave = new FileSavePicker();
                fileSave.FileTypeChoices.Add("Image", new string[] { ".jpg" });
                var storageFile = await fileSave.PickSaveFileAsync();
                using (var stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await imageStream.AsStreamForRead().CopyToAsync(stream.AsStreamForWrite());
                }
            }
        }
    }
