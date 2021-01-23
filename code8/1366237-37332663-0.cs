    Rectangle spriteRect;
    MouseState ms, oldms;
    protected override void Initialize()
    {
        // Set mouse visible
        IsMouseVisible = true;
        spriteRect= new Rectangle(/*foo*/);
        base.Initialize();
    }
    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        mSpriteBatch = new SpriteBatch(GraphicsDevice);
    }
    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// game-specific content.
    /// </summary>
    protected override void UnloadContent()
    {
        // TODO: Unload any non ContentManager content here
    }
    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        ms=Mouse.GetState();
        Rectangle mouseRect= new Rectangle((int)ms.X,(int)ms.Y,1,1);
       
       if(ms.LeftButton==ButtonState.Pressed && oldms.LeftButton!=ButtonState.Pressed){
    if(mouseRect.Intersects(spriteRect))
            {
               //play a sound
            }
    else{
    //play a different sound
    }
           
        }
 
        base.Update(gameTime);
        }
    }
   
