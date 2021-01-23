    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        int xmax = Screen.PrimaryScreen.Bounds.Width - 32;
        int ymax = Screen.PrimaryScreen.Bounds.Height - 32;
        for (int i = 0; i < 10; i++)
        {
            int x = Test.Location.X;
            int y = Test.Location.Y;
            if (e.KeyCode == Keys.Right && x < xmax) x += 2;
            if (e.KeyCode == Keys.Left && x > 0) x -= 2;
            if (e.KeyCode == Keys.Up && y > 0) y -= 2;
            if (e.KeyCode == Keys.Down && y < ymax) y += 2;
            Test.Location = new Point(x, y);
            Application.DoEvents();
        }
    }
