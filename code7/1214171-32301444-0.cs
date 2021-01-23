    var pos = button.PointToClient(Cursor.Position);
    System.Diagnostics.Debug.WriteLine(pos);         // Now it is easy
    if (button.ClientRectangle.Contains(pos)) {
        // etc...        
    }
