    public void RectangleInteraction(Rectangle anotherRectangle)
    {
        Rectangle down = playerRectangle; down.Offset(0, distance);
        Rectangle up = playerRectangle; down.Offset(0, -distance);
        Rectangle left = playerRectangle; down.Offset(-distance, 0);
        Rectangle right = playerRectangle; down.Offset(distance, 0);
        ConGoBot = !down.Intersects(anotherRectanlge); 
        ConGoTop = !up.Intersects(anotherRectanlge); 
        ConGoLeft = !left.Intersects(anotherRectanlge); 
        ConGoRight = !right.Intersects(anotherRectanlge); 
    }
