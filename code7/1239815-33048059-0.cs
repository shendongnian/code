    private static void HandleCollisionWithTile(Player player, Rectangle playerRect, Rectangle tileRect)
    {
        // Make sure there's even collosion
        if (!playerRect.Intersects(tileRect)) return;
    
        // Left
        if (player.Velocity.X < 0)
            player.Sprite.position.X = tileRect.Right + 1;
    
        // Right
        else if (player.Velocity.X > 0)
            player.Sprite.position.X = tileRect.Left - player.Sprite.SourceRect.Width - 1;
    
        // Up
        else if (player.Velocity.Y < 0)
            player.Sprite.position.Y = tileRect.Bottom + 1;
    
        // Down
        else if (player.Velocity.Y > 0)
            player.Sprite.position.Y = tileRect.Top - player.Sprite.SourceRect.Height - 1;
    
        // Reset velocity
        player.Velocity = Vector2.Zero;
    }
