        private void pnlDesign_MouseClick(object sender, MouseEventArgs e)
        {
            using (Brush brush = new SolidBrush(Color.Red))
            {
                g.FillRectangle(brush, GetRectangle(e.X, e.Y));
            }    
        }
        private Rectangle GetRectangle(int X, int Y)
        {
            return listRec.Where(item => X <= item.X + item.Width &&
                                         Y <= item.Y + item.Height).First();
        }
