        private System.Drawing.Bitmap TakeScreenshot()
        {
            int StartX, StartY;
            int Width, Height;
            StartX = 0;
            StartY = 0;
            Width = Convert.ToInt32(this.Width);
            Height = Convert.ToInt32(this.Height);
            System.Drawing.Bitmap Screenshot = new System.Drawing.Bitmap(Width, Height);
            System.Drawing.Graphics G = System.Drawing.Graphics.FromImage(Screenshot);
            G.CopyFromScreen(StartX, StartY, 0, 0, new System.Drawing.Size(Width, Height));
            return Screenshot;
        }
