       private void pnlDesign_MouseClick(object sender, MouseEventArgs e)
        {
            int clickedX = e.X;
            int clickedY = e.Y;
            using (Brush brush = new SolidBrush(Color.Red))
            {
                g.FillRectangle(brush, GetRectangle(clickedX, clickedY));
            }    
        }
        private Rectangle GetRectangle(int X, int Y)
        {
            Rectangle r = listRec.Where(item => item.X <= (X + (item.Width - item.X)) &&
                                                item.Y <= (Y + (item.Height - item.Y))).Last();                       
            return r;
        }
