    public MainWindow(string code)
    {
        InitializeComponent();
        BarCodeLabel.Content = BarcodeConverter128.StringToBarcode(code);
    }
    public void Print()
    {
        PrintDialog dlg = new PrintDialog();
        if (dlg.ShowDialog() == true)
        {
            dlg.PrintVisual(StuffToPrint, "Barcode");
        }
    }
