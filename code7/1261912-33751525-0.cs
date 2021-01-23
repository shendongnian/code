        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseClick += pictureBox1_MouseClick;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.X + " - " + e.Y);
        }
