    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        int x1, y1, width1, height1;
        public int Width1
        {
            get { return width1; }
            set { width1 = value; this.Invalidate(); }
        }
        public int Height1
        {
            get { return height1; }
            set { height1 = value; this.Invalidate(); }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            x1 = 10; y1 = 10; Width1 = 100; Height1 = 100;
            this.width1TextBox.DataBindings.Add("Text", this, "Width1", true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.height1TextBox.DataBindings.Add("Text", this, "Height1", true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.Paint += ProductListForm_Paint;
        }
        void ProductListForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Red, x1, y1, Width1, Height1);
        }
    }
