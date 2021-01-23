    Colliding = false;
    for (int x = 0; x < Tilemap.MAP_WIDTH; x++)
    {
        for (int y = 0; y < Tilemap.MAP_HEIGHT; y++)
        {
            if (tm.tile[x, y].bounds.Intersects(playerBounds) && tm.tile[x, y].getSolid())
            {
                Colliding = true;
                break;                    
            }
        }
        if(Colliding)
            break;
    }
