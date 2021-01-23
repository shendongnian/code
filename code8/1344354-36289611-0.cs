    public void Update(GameTime gameTime, MouseState mouse)
    {
        // burger should only respond to input if it still has health
        // move burger using mouse
        if (health > 0)
        {
            //if mouse is within borders, continue with position update.
            if(mouse.X > 0 && mouse.X < windowWidth && mouse.Y > 0 && mouse.Y < windowHeight){
               drawRectangle.X = mouse.X;
               drawRectangle.Y = mouse.Y;
            }
        }
    }
