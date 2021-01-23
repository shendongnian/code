    private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            foreach (Point line in lines)
            {
                g.DrawLine(new Pen(Brushes.Black, 5f), line.P1, line.P2);
                g.FillEllipse(Brushes.Red, line.P1.X - 2.5f, line.P1.Y - 2.5f, 5, 5);
                g.FillEllipse(Brushes.Red, line.P2.X - 2.5f, line.P2.Y - 2.5f, 5, 5);
                g.DrawEllipse(new Pen(Brushes.Red, 5f), line.P1.X, line.P1.Y, 1, 1);
                g.DrawEllipse(new Pen(Brushes.Red, 5f), line.P2.X, line.P2.Y, 1, 1);
            }
        }
