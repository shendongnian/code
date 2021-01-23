    while (eyeangle != angleVert)
    {
        if (eyeangle < angleVert)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 10);
        }
    
        if (eyeangle > angleVert)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 10);
        }
    }
