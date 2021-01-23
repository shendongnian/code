    public void RectangleInteraction(Rectangle anotherRectangle)
    {
        Rectangle down = playerRectangle; down.Offset(0, distance);
        Rectangle up = playerRectangle; up.Offset(0, -distance);
        Rectangle left = playerRectangle; left.Offset(-distance, 0);
        Rectangle right = playerRectangle; right.Offset(distance, 0);
        ConGoBot = !down.Intersects(anotherRectanlge); 
        ConGoTop = !up.Intersects(anotherRectanlge); 
        ConGoLeft = !left.Intersects(anotherRectanlge); 
        ConGoRight = !right.Intersects(anotherRectanlge); 
    }
