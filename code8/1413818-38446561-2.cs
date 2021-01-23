    public void HighLightNearbyDots(Point _mousePosition)
    {
        // ..
    
        CursorShape = Cursors.Arrow;
        foreach (var point in myDisplayedCoords)
        {
            Distance = (int)(MousePosition - point); // this gets the distance between two points and converts it to an int
    
            if (Distance < 10)
            {
                CursorShape = Cursors.Hand;
                point.Color = Colors.Red;
            }
            else
                point.Color = InitialCoordColor;
        }
        DrawImage();
    }
