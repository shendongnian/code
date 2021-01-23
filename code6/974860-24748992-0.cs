    public ImageWindow()
    {
        InitializeComponent();
        //this line will always have error as ImageToDisplay is set after the constructor
        //Imagee.Source = ImageToDisplay.Source;
    }
