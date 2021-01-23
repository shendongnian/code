    private void frmCalibration_Load(object sender, EventArgs e)
    {
    
            // Set colors.
            tileViewWaves.Appearance.ItemNormal.BackColor = _controlWaveColor;
            tileViewWaves.Appearance.ItemFocused.BackColor = _selectedWavePointColor;
            tileViewWaves.Click += tileViewWaves_Click;
    
    }
