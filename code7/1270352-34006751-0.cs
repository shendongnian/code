        private Button btn;
        public Form1()
        {
            InitializeComponent();
            btn = new Button()
            {
                Text = "0",
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 0),
                Size = new Size(30, 30),
            };
            this.Controls.Add(btn);
            this.ClientSize = new Size(btn.Width * 7, btn.Height * 3);
            btn.Move += btn_Move;
            this.MouseClick += Form1_MouseEvent;
            this.MouseWheel += Form1_MouseEvent;
        }
        private void btn_Move(object sender, EventArgs e)
        {
            btn.Text = CalculateIndex().ToString();
        }
        private int CalculateIndex()
        {
            return ((btn.Location.Y / btn.Height) * (btn.Parent.Width / btn.Width)) + 
                   (btn.Location.X / btn.Width);
        }
        void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn.Location = new Point(0, 0);
        }
        private void Form1_MouseEvent(object sender, MouseEventArgs e)
        {
            // moving horizontally with left and right buttons
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                btn.Left -= btn.Width;
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                btn.Left += btn.Width;
            // moving vertically with mouse wheel
            else if (e.Delta > 0)
                btn.Top -= btn.Height;
            else if (e.Delta < 0)
                btn.Top += btn.Height;
        }
    }
