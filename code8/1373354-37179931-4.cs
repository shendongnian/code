    private void panel1_MouseClick(object sender, MouseEventArgs e)
    {
        Color c = ((Bitmap)panel1.BackgroundImage).GetPixel(e.X, e.Y);
        if (e.Button.HasFlag(MouseButtons.Left))
        { 
            richTextBox1.SelectionColor = c;
        }
        else  // pick new BackColor:
        { 
            richTextBox1.SelectionBackColor = c;
        }
    }
       
