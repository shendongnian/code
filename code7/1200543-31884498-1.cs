    public MainForm()
    {
        InitializeComponent();
        InitSkinGallery();
        UserLookAndFeel.Default.SkinName = Settings.Default["ApplicationSkinName"].ToString();
        lastVisitedCustomers = (StringDictionary)Settings.Default["LastVisitedCustomer"];
    }
