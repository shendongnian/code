    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button.HasFlag(MouseButtons.Left)) A = e.Location;
        else B = e.Location;
        doTheDraw(pictureBox1);
    }
