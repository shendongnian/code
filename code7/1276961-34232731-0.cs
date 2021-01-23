    //Acquire storagefile via a picker or something
    public StorageFile CurrentFile
    {
        get { return currentImage; }
        set {
            SetValue(ref currentImage, value); 
            CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => SetCurrentImageAsync(value));
        }
    }
