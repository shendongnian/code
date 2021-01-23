    public Form1 ()
    {
        InitializeComponent();
        panel1.Invalidate(); //trigger paint
    }
    
    private void panel1_Paint ( object sender, PaintEventArgs e )
    {
        var result = e.Graphics.PageUnit; //breakpoint here
    }
