        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            int pX = e.X;
            int pY = e.Y;
            Graphics g = this.CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, pX, pY, 10, 10);//Size just for testing purposes
        }
