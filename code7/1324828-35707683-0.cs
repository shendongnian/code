    public void MoveCursor()
    {
      
        Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
        Cursor.Clip = new Rectangle(Cursor.Position, Cusror.Current.Size);
    }
