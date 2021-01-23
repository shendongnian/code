    public SW1(string skin)
    {
        InitializeComponent();
        SetSkin(skin);
        Loaded += OnSkinChanged;
        DataContext = this;
        IsBlinking = false;
    }
