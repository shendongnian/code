    private void panel1_MouseClick(object sender, MouseEventArgs e)
    {
        if ( richTextBox1.SelectionLength == 0)
             richTextBox1.SelectionStart = richTextBox1.Text.Length;
       
        Color c = ((Bitmap)panel1.BackgroundImage).GetPixel(e.X, e.Y);
        if (e.Button.HasFlag(MouseButtons.Left))
        { 
            richTextBox1.SelectionColor = c;
        }
        else
        { 
            richTextBox1.SelectionBackColor = c;
        }
    }
