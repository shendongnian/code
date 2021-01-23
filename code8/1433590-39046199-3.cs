        private void pnlDesign_MouseClick(object sender, MouseEventArgs e)
        {
            using (Brush brush = new SolidBrush(Color.Red))
            {
                g.FillRectangle(brush, GetRectangle(e.X, e.Y));
            }    
        }
        private Rectangle GetRectangle(int X, int Y)
        {
           return listRec.Where(r => r.Contains(new Point { X = X, Y = Y })).First();        
        }
