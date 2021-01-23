    public myClass()
    {
        ...
        alpha = 1.0f; // I'm almost sure that 1 means solid
    }    
    public void Update(GameTime gameTime)
    {
        if (alpha > 0.0f) alpha -= 0.01f;
    }
