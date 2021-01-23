    public MainViewModel()
    {
        FrameItems = new ObservableCollection<ViewModelbase> {
            new IceCreamMenu(),
            new SmurfOptions(),
            new MagicSparklePonyFourierTransformConfiguration()
        };
    }
