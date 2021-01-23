    private void ClearSheet()
    {
        if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
        Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
        using (Graphics G = Graphics.FromImage(bmp)) G.Clear(Color.Black);
        pictureBox1.Image = bmp;
        currentLine.Clear();
    }
    private void cb_clear_Click(object sender, EventArgs e)
    {
        ClearSheet();
    }
