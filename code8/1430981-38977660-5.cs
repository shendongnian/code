    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (HitTest(pictureBox1,e.X, e.Y))
            pictureBox1.Cursor = Cursors.Hand;
        else
            pictureBox1.Cursor = Cursors.Default;
    }
    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        if (HitTest(pictureBox1, e.X, e.Y))
            MessageBox.Show("Clicked on Image");
    }
