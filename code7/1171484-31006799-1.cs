      public override void Update()
    {
        rotation = point_direction(position.X, position.Y, Player.player.position.X, Player.player.position.Y);
        distance = sqrt(xdiff^2 + ydiff^2) <-- This line is pseudo-code
        if(distance<detectionDistance)
        {
            speed = spd;
        } 
        else
        {
            speed = 0
        }
        
        base.Update();
    }
