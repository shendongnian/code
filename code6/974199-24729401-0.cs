    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    namespace Proj06
    {
        public class Game1 : Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
            private Texture2D textureImage;
            private Point frameSize = new Point(52, 50);
            private Point currentFrame = new Point(0, 0);
            private Point sheetSize = new Point(4, 1);
            private Vector2 position = Vector2.Zero;
            private int collisionOffset = 1;
            private Vector2 speed;
            private UserControlledSprite userControlledSprite1;
            public Game1()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }
            protected override void LoadContent()
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);
                textureImage = Content.Load<Texture2D>(@"images/Picture");
                userControlledSprite1 = new UserControlledSprite(this, spriteBatch, textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed);
                Components.Add(userControlledSprite1);
            }
            protected override void Update(GameTime gameTime)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    Exit();
                base.Update(gameTime);
            }
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Begin();
                base.Draw(gameTime);
                spriteBatch.End();
            }
        }
    }
