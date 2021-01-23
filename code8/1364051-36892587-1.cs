    public void Update(GameTime gameTime)
    {
        if (Input.IsKeyPressed(Keys.P))
            scale.X += .05f;
        if (Input.IsKeyPressed(Keys.M))
            scale.X -= .05f;
        if (Input.IsKeyPressed(Keys.O))
        {
            scale.Y += .05f;
            marioPosition.Y -= scale.Y * (Sprites.MARIO.Height / 2f);
        }
        if (Input.IsKeyPressed(Keys.L))
        {
            scale.Y -= .05f;
            marioPosition.Y += scale.Y * (Sprites.MARIO.Height / 2f);
        }
        if (Input.IsKeyPressed(Keys.D))
            rotation += MathHelper.ToRadians(5);
        if (Input.IsKeyPressed(Keys.Q))
            rotation -= MathHelper.ToRadians(5);
        Input.Update(gameTime);
    }
The only reason I changed scale += new Vector2(0.0f, 0.05f); to scale.Y += .05f; is for you to see that it can be done faster, and you can make your code more readable.
