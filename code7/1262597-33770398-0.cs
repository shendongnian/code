        private void DrawSquare(object sender, MouseEventArgs e)
        {
            int pX = e.X;
            int pY = e.Y;
            
            int pSize = 10;
            Graphics g = this.CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, pX, pY, pSize, pSize);
        }
