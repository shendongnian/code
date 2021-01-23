    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        currentLine.Add(e.Location);
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            currentLine.Add(e.Location);
            drawIntoImage();
        }  
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        currentLine.Clear();
    }
