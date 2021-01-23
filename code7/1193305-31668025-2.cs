        private IEnumerator<Image> frames;
        private System.Windows.Forms.Timer tmr;
        private void Form1_Shown(object sender, EventArgs e)
        {
            List<Image> lstFrames = new List<Image>();
            lstFrames.Add(pictureBox2.BackgroundImage);
            lstFrames.Add(pictureBox3.BackgroundImage);
            lstFrames.Add(pictureBox4.BackgroundImage);
            // etc...
            frames = lstFrames.GetEnumerator();
            DisplayNextFrame();
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 500;
            tmr.Tick += Tmr_Tick;
            tmr.Start();
        }
        private void Tmr_Tick(object sender, EventArgs e)
        {
            DisplayNextFrame();
        }
        private void DisplayNextFrame()
        {
            if (!frames.MoveNext())
            {
                frames.Reset();
                frames.MoveNext();
            }
            pictureBox1.BackgroundImage = frames.Current;
        }
