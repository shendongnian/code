    // to be used to hold the Image collection instead of ImageList, LargeImageList, etc
    private Dictionary<string, Image> _images;
    // to be used for the default node image if none found in _images
    public Image FolderImage { get; }
    // TODO: to be used for the default open node image if none found in _images
    public Image FolderImageOpen { get; }
