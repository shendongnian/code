    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        public IList<Ball> Balls { get; private set; }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            var rand = new Random();
            Balls = new List<Ball>(5);
            for(var iii = 0; iii < 100; ++iii)
                Balls.Add(new Ball(GraphicsDevice, new Vector2(rand.Next(50, 500), rand.Next(50, 500))));
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
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
            foreach (var ball in Balls)
                ball.Update(gameTime);
            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach (var ball in Balls)
                ball.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
    public class Ball
    {
        public Texture2D Texture { get; }
        public Vector2 Position { get; private set; }
        public double Scale { get; private set; }
        public Ball(GraphicsDevice gd, Vector2 initialPosition)
        {
            Texture = new Texture2D(gd, 50, 50);
            Position = initialPosition;
            var data = new Color[100*100];
            for (var iii = 0; iii < data.Length; ++iii) data[iii] = Color.YellowGreen;
            Texture.SetData(data);
        }
        private bool _increaseScale, _increaseX, _increaseY;
        public void Update(GameTime gameTime)
        {
            if (Scale < 1)
                _increaseScale = true;
            else if (Scale > 4)
                _increaseScale = false;
            if (Position.X < 50)
                _increaseX = true;
            else if (Position.X > 500)
                _increaseX = false;
            
            if (Position.Y < 50)
                _increaseY = true;
            else if (Position.Y > 500)
                _increaseY = false;
            Scale += (_increaseScale ? 1.5 : -1.5) * gameTime.ElapsedGameTime.TotalSeconds;
            Position += new Vector2((float)((_increaseX ? 100 : -100)*gameTime.ElapsedGameTime.TotalSeconds), (float)((_increaseY ? 100 : -100)*gameTime.ElapsedGameTime.TotalSeconds));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            var source = new Rectangle(0, 0, Texture.Height, Texture.Width);
            var dest = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width * (int)Scale, Texture.Height* (int)Scale);
            spriteBatch.Draw(Texture, dest, source, Color.White);
        }
    }
