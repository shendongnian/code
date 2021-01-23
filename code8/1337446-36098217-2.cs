    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Enemy> enemies = new List<Enemy>();
        Random rand = new Random();
        
        private void CreateEnemy()
        {
            Enemy gear = new Enemy();
            
            //gear = new Enemy();
            gear.Position.X = rand.Next(0, 1000);
            gear.Position.Y = rand.Next(0, 1000);
            Console.WriteLine(gear.Position.Y);
            enemies.Add(gear);
            enemies[0].Position.X += 10;
           
        }
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            for (int i = 0; i < 5; i++)
            {
                CreateEnemy();
            }
            foreach (var cog in enemies)
            {
                cog.LoadContent(this.Content);
            }
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
            // TODO: Add your update logic here
            foreach (var cog in enemies)
            {
                if (cog.Position.X > Window.ClientBounds.Width - 50)
                    cog.Position.X = Window.ClientBounds.Width - 50;
                if (cog.Position.Y > Window.ClientBounds.Height - 50)
                    cog.Position.Y = Window.ClientBounds.Height - 50;
                if (cog.Position.X < 0)
                    cog.Position.X = 0;
                if (cog.Position.Y < 0)
                    cog.Position.Y = 0;
            }
            foreach (var cog in enemies)
            {
                cog.Update(gameTime);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
                // If 'm' is down, we create a new meteor. Note that once this is working
                // this is going to make a lot of meteors. That's another issue, though.
                CreateEnemy();
            }
            //Console.WriteLine(enemies.Count);
            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (var cog in enemies)
            {
               cog.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
      }
    }
