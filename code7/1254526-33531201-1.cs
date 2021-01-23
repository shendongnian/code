    public Form1()
    {
        InitializeComponent();
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);   
        //Or Turn off DoubleBuffered
        //this.DoubleBuffered = false; 
    }
    //draw image wherever you want
    protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
    {
        e.Graphics.DrawImage(this.BackgroundImage, new System.Drawing.Point(0, 0));
    }
