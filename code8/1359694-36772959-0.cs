You just have to know the calling order of functions of Game1. First, Game1 constructor is called. That's where you've put mainMenu = new MainMenu();. After that go Initialize, Load and so on. You have to move mainMenu = new MainMenu(); from Game1 constructor to Load function, after the Resources.LoadContent(Content);, so the resources can be loaded before they are used in MainMenu. Your Game1.cs code should look like this:
    public class GameMain : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
    
        MainMenu mainMenu;
    
        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
    
            this.IsMouseVisible = true;
        }
    
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
    
            base.Initialize();
        }
    
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
    
            // TODO: use this.Content to load your game content here
            Resources.LoadContent(Content);
            mainMenu = new MainMenu();
        }
    
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
    
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
    
            // TODO: Add your update logic here
            base.Update(gameTime);
        }
    
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
    
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            mainMenu.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
