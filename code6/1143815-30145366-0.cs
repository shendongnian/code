    // if the player is at the bottom of the screen
    if (player.Bottom >= screen.Bottom) 
    {
        jump = false;
    }
    // if the player is hitting a block
    else if (player.Right >= block.Left &&
        player.Left <= block.Right &&
        player.Bottom >= block.Top &&
        player.Top <= block.Bottom)
    {
        force = 0;
        jump = false;
    }
    else
    {
        player.Top += 5;
        jumped = false;
        nothing = false;
    }
