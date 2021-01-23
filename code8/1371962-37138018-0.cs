Try this modified version of your Update function:
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();
        MouseState mouse = Mouse.GetState();
        //Debug.WriteLine(mouse);
        btn.Update(mouse);
        if (btn.Clicked == true)
        {
            Debug.WriteLine("Clicked");
            currentState = GameState.Playing;
        }
        base.Update(gameTime);
    }
