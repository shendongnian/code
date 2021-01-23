    public void update(GameTime gameTime, Vector2 playerPosition)
    {
        float angle = MathHelper.ToDegrees((float)Math.Atan2(playerPosition.Y - position.Y, playerPosition.X - position.X));
        float rotationDegrees = MathHelper.ToDegrees(rotationAngle);
        var diff = ((rotationDegrees - angle) + 360) % 360;
        if (diff > 90)
        {
            // bool for rotate method determines if rotating left or right
            rotate(false);
        }
        else
        {
            rotate(true);
        }
        if (diff < 180 && diff > 0)
        {
            moveForward();
        }
        update(gameTime);
    }
