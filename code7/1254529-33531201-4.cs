    public Form1()
    {
        InitializeComponent();  
        this.DoubleBuffered = false; 
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
    }
    //draw image wherever you want
    protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
    {
        e.Graphics.DrawImage(this.BackgroundImage, new System.Drawing.Point(0, 0));
    }
