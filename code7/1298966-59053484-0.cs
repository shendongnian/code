    public FormMain()
            {
                bcl.OnScan +=new Barcode2.OnScanHandler(bcl_OnScan);
                bcl.Config.Decoders.I2OF5.Enabled = true;
                bcl.Config.Decoders.CODE128.Enabled = false;
                bcl.Config.Decoders.I2OF5.MinLength = 6;
                bcl.Config.Decoders.I2OF5.MaxLength = 8;
                bcl.Scan();
                InitializeComponent();
            }
