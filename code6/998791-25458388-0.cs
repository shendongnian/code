    using SharpDX;
    using SharpDX.Toolkit;
    
    namespace App1 {
        internal class MyGame : Game {
            private GraphicsDeviceManager _manager;
    
            public MyGame() {
                _manager = new GraphicsDeviceManager(this);
            }
            
            protected override void Draw(GameTime gameTime) {
    #if WINDOWS_APP
        // desktop related
    #elif WINDOWS_PHONE_APP
        // phone related
    #endif
                GraphicsDevice.Clear(Color.Magenta);
                base.Draw(gameTime);
            }
        }
    }
