    KeyboardState oldState;
    KeyboardState currentState;
    public void Load()
    {
        oldstate = Keyboard.GetState();
    }
    public void Update(GameTime gameTime)
    {
        currentState = Keyboard.GetState();
        //Example below
        
        if (oldState.IsKeyUp(Keys.Space)
        && currentState.IsKeyDown(Keys.Space))
        {
           //Play Sound
        }
        oldState = currentState;
    }
