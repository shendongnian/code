    public Rectangle? GetSelected(List<Rectangle> squares)
    {
        Rectangle mousePosition = new Rectangle(mouseX, mouseY, charWidth, charheight);
        
        foreach (var rect in squares)
        {
            if (rect.Contains(mousePosition))
            {
                return rect;
            }
        }
        return null;
    }
