    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    namespace Proj06
    {
        class UserControlledSprite : Sprite
        {
            public UserControlledSprite(Game game, SpriteBatch sb, Texture2D textureImage, Vector2 position,
                Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
                Vector2 speed)
                : base(game, sb, textureImage, position, frameSize, collisionOffset, currentFrame,
                sheetSize, speed)
            {
            }
            public UserControlledSprite(Game game, SpriteBatch sb, Texture2D textureImage, Vector2 position,
                Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
                Vector2 speed, int millisecondsPerFrame)
                : base(game, sb, textureImage, position, frameSize, collisionOffset, currentFrame,
                sheetSize, speed, millisecondsPerFrame)
            {
            }
            public override Vector2 direction
            {
                get
                {
                    Vector2 inputDirection = Vector2.Zero;
                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                        inputDirection.X -= 1;
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                        inputDirection.X += 1;
                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                        inputDirection.Y -= 1;
                    if (Keyboard.GetState().IsKeyDown(Keys.Down))
                        inputDirection.Y += 1;
                    return inputDirection * speed;
                }
            }
            public override void Update(GameTime gameTime, Rectangle clientBounds)
            {
                position += direction;
                if (position.X < 0)
                    position.X = 0;
                if (position.Y < 0)
                    position.Y = 0;
                if (position.X > clientBounds.Width - frameSize.X)
                    position.X = clientBounds.Width - frameSize.X;
                if (position.Y > clientBounds.Height - frameSize.Y)
                    position.X = clientBounds.Height - frameSize.Y;
                base.Update(gameTime, clientBounds);
            }
        }
    }
