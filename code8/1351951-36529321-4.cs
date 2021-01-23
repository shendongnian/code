    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (!e.Button.HasFlag(MouseButtons.Left)) return;
        textLocation = e.Location;
        pictureBox1.Invalidate();
    }
