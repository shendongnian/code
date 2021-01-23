    public static void Main()
    {
        Cursor myCursor = new Cursor(Cursor.Current.Handle);
        myCursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y);
        myCursor.Clip = new Rectangle(this.Location, this.Size);
    }
