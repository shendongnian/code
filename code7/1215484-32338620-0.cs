        private AnimatedTexture SpriteTexture;
        private const float Rotation = 0;
        private const float Scale = 2.0f;
        private const float Depth = 0.5f;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            SpriteTexture = new AnimatedTexture(Vector2.Zero,
                Rotation, Scale, Depth);
    #if ZUNE
            // Frame rate is 30 fps by default for Zune.
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 30.0);
    #endif
        }
