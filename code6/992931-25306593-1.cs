    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera Camera;
    
        Texture2D LineTexture;
        List<Line> Lines;
        Random Random;
    
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
                   
        protected override void Initialize()
        {
            base.Initialize();
        }
    
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Camera = new Camera(GraphicsDevice.Viewport, 1f);
    
            LineTexture = new Texture2D(GraphicsDevice, 1, 1);
            LineTexture.SetData<Color>(new Color[] { Color.White });
    
            Random = new Random();
            Lines = new List<Line>();
        }
    
        protected override void UnloadContent()
        {
        }
    
           
        protected override void Update(GameTime gameTime)
        {
            //handle input
            KeyboardState kbState = Keyboard.GetState();
    
            if (kbState.IsKeyDown(Keys.Escape))
                this.Exit();
    
            if (kbState.IsKeyDown(Keys.OemMinus))
                Camera.Zoom -= 0.015f;
            else if (kbState.IsKeyDown(Keys.OemPlus))
                Camera.Zoom += 0.015f;
    
            if (kbState.IsKeyDown(Keys.Up))
                Camera.Move(new Vector2(0, -30));
            else if (kbState.IsKeyDown(Keys.Down))
                Camera.Move(new Vector2(0, 30));
            if (kbState.IsKeyDown(Keys.Left))
                Camera.Move(new Vector2(-30, 0));
            else if (kbState.IsKeyDown(Keys.Right))
                Camera.Move(new Vector2(30, 0));
    
    
            //check if line is still in viewport - if not remove it
            for (int i = 0; i < Lines.Count; i++)
            {
                if (Lines[i].PointB.X < Camera.Viewport.X)
                {
                    Lines.RemoveAt(i);
                    i--;
                }
            }
    
            //if there are no lines, create one to get started
            if (Lines.Count == 0)
            {
                Vector2 p1 = new Vector2(Camera.Viewport.X, Random.Next(Camera.Viewport.Y + 50, Camera.Viewport.Height - 100));
                Vector2 p2 = new Vector2(p1.X + Random.Next(5, 20), p1.Y + Random.Next(-5, 5));
                Line line = new Line(p1, p2, 1, Color.Black, LineTexture);
                Lines.Add(line);
            }
    
            //Check if we need to add some lines to the right of our last list item
            while (Lines[Lines.Count - 1].PointB.X < Camera.Viewport.X + Camera.Viewport.Width)
            {
                Vector2 p1 = new Vector2(Lines[Lines.Count - 1].PointB.X, Lines[Lines.Count - 1].PointB.Y); ;
                Vector2 p2 = new Vector2(p1.X + Random.Next(5, 20), p1.Y + Random.Next(-5, 5));
                Line line = new Line(p1, p2, 1, Color.Black, LineTexture);
                Lines.Add(line);
            }
    
            base.Update(gameTime);
        }
    
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(30, 90, 150));
    
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Camera.View);
    
            foreach (Line line in Lines)
                line.Draw(spriteBatch);
    
            spriteBatch.End();
    
            base.Draw(gameTime);
        }
    }
