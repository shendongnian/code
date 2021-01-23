    System.Drawing.Rectangle player = new Rectangle(width, height, x, y);
    Rectangle item = new Rectangle(width, height, x, y);
    if(player.Intersects(item))
    {
      canJump = false;
    }
