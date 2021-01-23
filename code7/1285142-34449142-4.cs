    private void pictureBox1_MouseLeave(object sender, EventArgs e)
    {
        pan.Hide();       // !!
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        pan.Location = pictureBox1.PointToClient(Cursor.Position);       // !!
        pictureBox1.Refresh();       // !!
    }
    private void pictureBox1_MouseEnter(object sender, EventArgs e)
    {
        pan.Height = 200;
        pan.Width = 100;
        pan.BackColor = Color.Blue;
        pictureBox1.Controls.Add(pan);              // !!
        pan.Location = pictureBox1.PointToClient(Cursor.Position);  // !!
        pan.Show();     // !!
    }
