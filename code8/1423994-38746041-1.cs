    private async void itemclicked(object sender, ItemClickEventArgs e)
    {
        var file = e.ClickedItem as StorageFile;
        if(file != null)
        {
            var stream = await file.OpenReadAsync();
            mediaElement.SetSource(stream, file.ContentType);
        }
    }
