    private void mouseClick1(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            Trace.WriteLine("Mouse clicked");
            switcher.Value = true; 
        }
    }
