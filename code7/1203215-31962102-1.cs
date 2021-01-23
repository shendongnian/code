    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        graphics.IsFullScreen = false;
        graphics.PreferredBackBufferWidth = 800;
        graphics.PreferredBackBufferHeight = 950;
        this.Window.Title = "XNA Space Shooter";
       
        Content.RootDirectory = "Content";
    }
