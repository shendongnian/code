    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if(isDragging == true)
        {
            MovePictureBox(move, new Point(e.X, y.Y), pictureBox1);
        }
    }
