    MediaSource mediaSource = MediaSource.GetAvailableMediaSources()
                .First((source => source.MediaSourceType == MediaSourceType.LocalDevice));
    using (MediaLibrary mediaLibrary = new MediaLibrary(mediaSource))
    {
         PictureAlbum cameraRollAlbum = mediaLibrary.RootPictureAlbum.Albums.First((album) => album.Name == "Camera Roll");
         
    }
