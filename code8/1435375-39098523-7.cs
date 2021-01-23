    class MyControl: ..., IDisposable
    {
         private readonly Pen blackPen = new Pen(Brushes.Black, 5f));
         private readonly Pen redPen = new Pen(Brushes.Red, 5f));
         void Draw(object sender, PaintEventArgs e)
         {
             foreach (Line line in lines)
             {
                e.Graphics.DrawLine(blackPen, line.P1, line.P2);
                e.Graphics.FillEllipse(Brushes.Red, line.P1.X - 2.5f, line.P1.Y - 2.5f, 5, 5);
                e.Graphics.FillEllipse(Brushes.Red, line.P2.X - 2.5f, line.P2.Y - 2.5f, 5, 5);
                e.Graphics.DrawEllipse(redPen, line.P1.X, line.P1.Y, 1, 1);
                e.Graphics.DrawEllipse(redPen, line.P2.X, line.P2.Y, 1, 1);
            }
        }
        private void Dispose(bool disposing)
        {
             ....
             if (disposing)
             {
                 ....
                 blackPen.Dispose(;)
                 redPen.Dispose();
             }
        }
    }
