    private bool _isAllowMove = false;
    ...
    button1.MouseMove += new MouseEventHandler((object sender, MouseEventArgs e) => 
    {
        if(!_isAllowMove) {
            return;
        }
        button1.Location = this.PointToClient(Cursor.Position);
    });
    
    button1.MouseDown += new MouseEventHandler((object sender, MouseEventArgs e) => 
    {
        _isAllowMove = true;
    });
    
    button1.MouseUp += new MouseEventHandler((object sender, MouseEventArgs e) => 
    {
        _isAllowMove = false;
    });
