    Timer _tmrCsv = new Timer { Interval = 216000000 };
    private void Form2_Load(object sender, EventArgs e)
    {
        _tmrCsv.Tick += _tmrCsv_Tick;
        _tmrCsv.Enabled = true;
        
    }
    
    void _tmrCsv_Tick(object sender, EventArgs e)
    {
        CreateFile();
    }
