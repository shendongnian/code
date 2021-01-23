    public void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left) 
        {
            end = e.Location;
            Invalidate();
        }
    }
