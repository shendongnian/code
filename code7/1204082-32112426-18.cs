    private void panel1_MouseMove_1(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            currentLine.Add(e.Location);
            panel1.Invalidate();
        }  
    }
