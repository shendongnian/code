        public Form1()
        {
            InitializeComponent();
            panel1.MouseEnter += panel1_MouseEnter;
            panel1.MouseLeave += common_MouseLeave;
            label1.MouseLeave += common_MouseLeave;
        }
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            label1.Visible = true;
        }
        private void common_MouseLeave(object sender, EventArgs e)
        {
            Rectangle rc = panel1.RectangleToScreen(panel1.ClientRectangle);
            if (!rc.Contains(Cursor.Position))
            {
                label1.Visible = false;
            }
        }
