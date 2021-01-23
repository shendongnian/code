    public void Update(GameTime gameTime)
    {
        if (Input.IsKeyPressed(Keys.P))
            scale.X += .05f;
        if (Input.IsKeyPressed(Keys.M))
            scale.X -= .05f;
     
        //Solution ---------------------------------------------------
        if (Input.IsKeyPressed(Keys.O))
        {
            float previousSize = source.Height * scale.Y;
            float newSize = source.Height * (scale.Y + .05f);
            scale.Y += .05f;
            marioPosition.Y -= (Math.Abs(previousSize - newSize)/2)
        }
        if (Input.IsKeyPressed(Keys.L))
        {
            float previousSize = source.Height * scale.Y;
            float newSize = source.Height * (scale.Y - .05f);
            scale.Y -= .05f;
            marioPosition.Y += (Math.Abs(previousSize - newSize)/2)
        }
        //--------------------------------------------------------------
     
        if (Input.IsKeyPressed(Keys.D))
            rotation += MathHelper.ToRadians(5);
        if (Input.IsKeyPressed(Keys.Q))
            rotation -= MathHelper.ToRadians(5);
     
        Input.Update(gameTime);
    }
