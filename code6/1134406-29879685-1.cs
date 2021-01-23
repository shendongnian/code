        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(this.ClientRectangle.Width,
                             this.ClientRectangle.Height);         
        }
        Bitmap bmp = null;
