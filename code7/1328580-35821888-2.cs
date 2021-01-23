    private void MoveCursor()
    {
       //here Cursor is a form's property 
       this.Cursor = new Cursor(Cursor.Current.Handle); 
       // here Cursor is a class name, Position is a static variable.
       Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50); 
       // here Cursor is a class name, Clip is a static variable.
       Cursor.Clip = new Rectangle(this.Location, this.Size); 
    }
