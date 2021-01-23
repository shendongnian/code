    public Form1()
    {           
        InitializeComponent();
        CreateGraph();
        this.Text = "HRM File Analyser";
        hrCheck_CheckedChanged(null, null);   // set initial state
        ..
    }
    private void hrCheck_CheckedChanged(object sender, EventArgs e)
    {
        chart1.Series["Heart Rate"].Enabled = hrCheck.Checked;
    }
