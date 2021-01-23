    KeyboardState newState, oldState;
    public void Update(...)
    {
        //gets keyboard state for this single frame
        newState = Keyboard.GetState();
        //checks if enter is down
        if(newState.IsKeyDown(Keys.Enter))
        {
            *do what you want here*
        }
        
        // checks if enter is clicked
        // if statement asks if in this frame, enter button is down
        // AND if enter button was not down in the last frame
        // this way, if statement below will fire only on each click
        if(newState.IsKeyDown(Keys.Enter) && oldState.IsKeyUp(Keys.Enter))
        {
            *do what you want here*
        }
        
        //set old state to new state, so the next frame knows 
        //what was happening in frame before that one
        oldState = newState;
    }
