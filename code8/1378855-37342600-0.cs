        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = blue_box.Location.X;
            int y = blue_box.Location.Y;
            if (e.KeyCode == Keys.Right) x += 10;
            else if (e.KeyCode == Keys.Left) x -= 10;
            else if (e.KeyCode == Keys.Up) y -= 10;
            else if (e.KeyCode == Keys.Down) y += 10;
            blue_box.Location = new Point(x, y);
            if (blue_box.Bounds.IntersectsWith(red_box.Bounds))
            {
                //your logic to handle the collition
            }
        }
