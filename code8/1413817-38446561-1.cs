    public void HighLightNearbyDots(Point _mousePosition)
    {
        // ..
        bool handCursor = false;
        foreach (var point in myDisplayedCoords)
        {
            Distance = (int)(MousePosition - point); // this gets the distance between two points and converts it to an int
    
            if (Distance < 10)
            {
                handCursor = true;
                point.Color = Colors.Red;
            }
            else
                point.Color = InitialCoordColor;
        }
        CursorShape = handCursor ? Cursors.Hand : Cursors.Arrow;
        DrawImage();
    }
