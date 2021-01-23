    public partial class TransparentTextbox : TextBox
    {
        public Bitmap BgBitmap { get; set; }
    
        public TransparentTextbox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.ResizeRedraw |
                        ControlStyles.UserPaint, true);
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawString(this.Text, this.Font, Brushes.Black, new PointF(0.0F, 0.0F));
        }
    
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.DrawImage(BgBitmap, 0, 0);
        }
    }
