            if (e.KeyCode == Keys.A)
            {
                Graphics g = this.CreateGraphics();
                Pen pen = new Pen(Color.Black, 2);
                Brush brush = Brushes.Black;
                int x = 5;
                int y = 5;
                g.FillRectangle(brush, x, y, 55, 55);
            }
