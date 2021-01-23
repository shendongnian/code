    void label1_MouseDown(object sender, MouseEventArgs e)
    {
        start = e.Location;
        _mapPackageIsMoving = true;
        Cursor.Clip = panel2.ClientRectangle;
    }
    void label1_MouseUp(object sender, MouseEventArgs e)
    {
        _mapPackageIsMoving = false;
        Cursor.Clip = null;
    }
