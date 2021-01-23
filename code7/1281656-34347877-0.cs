        protected override void OnResize(EventArgs e)
        {
            pictureBox1.Left = 0;
            pictureBox1.Top = 0;
            pictureBox1.Width = Screen.PrimaryScreen.Bounds.Width;
            pictureBox1.Height = Screen.PrimaryScreen.Bounds.Height;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            base.OnResize(e);
        }
