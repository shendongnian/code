    // Keep a record of old rectangle
    Rectangle oldPos = player.Rectangle;
    
    // Update player position and rectangle here
    
    // Check for collision
    if (player.Rectangle.Intersects(wallRect))
    {
        // Player has hit the wall. Now to find out which direction it has come from
    
        if (oldRect.Center.X < wallRect.Center.X)
        {
            // Player came from left of wall
        }
        else
        {
            // Player came from right of wall
        }
    }
