    private void textBox1_MouseDown(object sender, MouseEventArgs e)
    {
        (sender as TextBox).Enabled = !(sender as TextBox).Enabled;
    }
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        var rect = RectangleToClient(textBox1.RectangleToScreen(textBox1.ClientRectangle));
        if (rect.Contains(e.Location))
        {
            textBox1.Enabled = !textBox1.Enabled;
            //  I added this because it felt very wrong for the TextBox not 
            //  to gain focus when I enable-clicked it. I think you'll agree.
            if (textBox1.Enabled)
            {
                textBox1.Focus();
            }
        }
    }
