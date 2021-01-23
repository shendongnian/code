    public MainWindow()
    {
        InitializeComponent();
        image.ImageFailed += ImageFailed;
    }
    private void ImageFailed(object sender, ExceptionRoutedEventArgs e)
    {
        Console.WriteLine(e.ErrorException);
    }
