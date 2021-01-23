    public DesktopLogin()
    {
        InitializeComponent();
        scanner = new MobileBarcodeScanner(this.Dispatcher);
        this.Loaded += MainPage_Loaded;
    }
    
    private async void MainPage_Loaded(object sender, RoutedEventArgs e) {
        scanner.UseCustomOverlay = false;
        scanner.UseCustomOverlay = false;
        scanner.TopText = "Hold camera up to barcode";
        scanner.BottomText = "Camera will automatically scan barcode\r\n\r\nPress the 'Back' button to Cancel";
    
        //Start scanning
        await scanner.Scan().ContinueWith(t =>
        {
            if (t.Result != null)
                processResult(t.Result);
        });
    }
    
    private void processResult(ZXing.Result result)
    {
        if ((result != null) && !string.IsNullOrEmpty(result.Text))
        {
            string qrCode = result.Text;
    
            this.Dispatcher.BeginInvoke(() =>
            {
                MessageBox.Show("QR Code is " + qrCode);
                NavigationService.Navigate(new Uri("/Catalog.xaml", UriKind.Relative));
                NavigationService.RemoveBackEntry();
            });
        }
        else
        {
            MessageBox.Show("Scanning Canceled!");
        }   
    }
