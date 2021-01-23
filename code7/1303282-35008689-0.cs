    private void picBox_MouseDown(object sender, MouseEventArgs e) 
    {
            mousePosition = e.Location;
    }
    private void picBox_MouseMove(object sender, MouseEventArgs e) 
    {
            if (e.Button == MouseButtons.Left) 
            {
                int dx = e.X - mousePosition.X;
                int dy = e.Y - mousePosition.Y;
                picBox.Location = new Point(picBox.Left + dx, picBox.Top + dy);
            }
    }
