    class game
    {
    
      public static Texture2d grass;
    
      public createMap map;
    
    
    protected override void LoadContent()
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);
                device = graphics.GraphicsDevice;
                background = Content.Load<Texture2D>("plain");
                player = Content.Load<Texture2D>("Player_Test");
                grass = Content.Load<Texture2D>("grass");
                dirt = Content.Load<Texture2D>("dirt");
                stone = Content.Load<Texture2D>("stone");
    //then create the map
                    map = new createMap();
                }
         //rest of class
    
    }
