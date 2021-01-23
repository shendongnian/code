    KeyboardState newState;
    public void Update(...)
    {
        newState = Keyboard.GetState();
        if(newState.IsKeyDown(Keys.Enter))
        {
            *do what you want here*
        }
    }
