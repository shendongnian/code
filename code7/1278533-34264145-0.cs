    public Form1()
    {
        InitializeComponent();
        foreach (Control control in Controls)
        {
           control.Cursor = Cursors.Hand;                
        }
    }
