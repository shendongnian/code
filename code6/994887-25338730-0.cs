    public void FetchPhotosFromAlbum()
    {
        if (listBoxPictures.InvokeRequired)
        {
           listBoxPictures.Invoke(new Action(FetchPhotosFromAlbum));
           return;
        }
         var allPhotosFromAlbum = AlbumName.Photos;
         photoBindingSource.DataSource = allPhotosFromAlbum;
         listBoxPictures.DisplayMember = "UpdateTime"
    }
