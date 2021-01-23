    public List<string> Uris;
    private ObservableCollection<MediaFile> _images;
    public  ObservableCollection<MediaFile> Images {
        get { return _images ?? (_images = new ObservableCollection< MediaFile >()); }
        set {
            if(_images != value) {
                _images = value;
                OnPropertyChanged();
            }
        }
    }
    /// <summary>
    /// Allows the user to pick a photo on their device using the native photo handlers and returns a stream, which we save to disk.
    /// </summary>
    /// <returns>string, the name of the image if everything went ok, 'false' if an exception was generated, and 'notfalse' if they simply canceled.</returns>
    public async Task<string> PickPictureAsync() {
        MediaFile file      = null;
        string    filePath  = string.Empty;
        string    imageName = string.Empty;
        try {
            file = await CrossMedia.Current.PickPhotoAsync();
            #region Null Check
             if(file == null) { return null; }                                                                                 //Not returning false here so we do not show an error if they simply hit cancel from the device's image picker
            #endregion
            imageName = "SomeImageName.jpg";
            filePath  = /* Add your own logic here for where to save the file */ //_fileHelper.CopyFile(file.Path, imageName);
        } catch(Exception ex) {
             Debug.WriteLine("\nIn PictureViewModel.PickPictureAsync() - Exception:\n{0}\n", ex);                           //TODO: Do something more useful
             return null;
        } finally { if(file != null) { file.Dispose(); } }
        Receipts.Add(ImageSource.FromFile(filePath));
        Uris.Add(filePath);
        return imageName;
    }
