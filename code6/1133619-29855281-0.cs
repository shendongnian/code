    ks = Keyboard.GetState();
    bool isMoving = false;
    if (ks.IsKeyDown(Keys.Right))
    {
        position.X += 3f;
        currentWalk = walkRight;
        isMoving = true;
    }
    if (ks.IsKeyDown(Keys.Left))
    {
        position.X -= 3f;
        currentWalk = walkLeft;
        isMoving = true;
    }
    if (ks.IsKeyDown(Keys.Down))
    {
        position.Y += 3f;
        currentWalk = walkDown;
        isMoving = true;
    }
    if (!isMoving)
    {
        //Do whatever you need to do when the player is still here
    }
