    this.MouseClick += mouseClick;
    
    private void mouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Trace.WriteLine("Mouse clicked");
            Console.WriteLine(Cursor.Position.ToString());
        }
    }
