    private void tabPage5_MouseDown(object sender, MouseEventArgs e)
    {
        m_Down = e.Location;  
        overlay.Size = Size.Empty; 
        overlay.Show();
        overlay.Refresh();
    }
    private void tabPage5_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            overlay.Location = tabPage5.PointToScreen(m_Down);
            overlay.Size = new Size(e.X - m_Down.X, e.Y - m_Down.Y);
        }
    }
    private void tabPage5_MouseUp(object sender, MouseEventArgs e)
    {
        // do your stuff and then hide overlay..
        overlay.Hide();
    }
