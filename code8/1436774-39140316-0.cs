    private void picB_MouseLeave(object sender, EventArgs e)
    {
        PictureBox pb = (PictureBox)sender;
        Button bt1 = (Button)pb.Controls[0];
        Button bt2 = (Button)pb.Controls[1];
        Point p = Control.MousePosition;
        if (bt1.ClientRectangle.Contains(bt1.PointToClient(p))  ||
            bt2.ClientRectangle.Contains(bt2.PointToClient(p))) return;
        bt1.Hide();
        bt2.Hide();
    }
