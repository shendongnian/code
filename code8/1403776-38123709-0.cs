        bool TrackFlag = false;
        public void ClickRibbon(Office.IRibbonControl control)
        {
            TrackFlag = true;
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            if (TrackFlag)
            {
                TrackFlag = false;
                int x = MousePosition.X;
                int y = MousePosition.Y;
                MessageBox.Show("Location (x,y) (" + x + "," + y + ")");
            }
        }
