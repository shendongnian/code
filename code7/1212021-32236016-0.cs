    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    
    namespace MyGame
    {
        public class MyGame : Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
    
            public MyGame()
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
            }
            protected override void UnloadContent()
            {
            }
            protected override void Update(GameTime gameTime)
            {
                base.Update(gameTime);
            }
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                base.Draw(gameTime);
            }
        }
    }
