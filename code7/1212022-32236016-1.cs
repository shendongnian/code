    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    
    namespace Test_Game
    {
        public class Main_Menu : Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
            Vector2 buttonPos; // our button position
            Texture2D button; // our button texture
    
            public MyGame()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }
            protected override void Initialize()
            {
                buttonPos = new Vector2(30, 30); // X=30, Y=30
                base.Initialize();
            }
            protected override void LoadContent()
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);
                button = Content.Load<Texture2D>("button_temp"); // load texture
            }
            protected override void UnloadContent()
            {
            }
            protected override void Update(GameTime gameTime)
            {
                // here we would add game logic
                // things like moving game objects, detecting collisions, etc
                base.Update(gameTime);
            }
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Begin();
                // draw our button
                int buttonWidth = 214;
                int buttonHeight = 101;
                spriteBatch.Draw(button, new Rectangle(buttonPos.X, buttonPos.Y, buttonWidth, buttonHeight), Color.White);
                spriteBatch.End();
                base.Draw(gameTime);
            }
        }
    }
