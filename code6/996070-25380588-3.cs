    public Form1()
    {
        InitializeComponent();
        SetStyle(
           ControlStyles.AllPaintingInWmPaint | 
           ControlStyles.OptimizedDoubleBuffer | 
           ControlStyles.ResizeRedraw | 
           ControlStyles.UserPaint,
           true);
    }
