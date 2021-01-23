    class TextureHolder
    {
        static private TextureHolder instance;
        private Texture2D texture;
        private TextureHolder()
        {
            texture = Content.Load<Texture2D>("Texture1");
        }
        public static GetTexture()
        {
             if(instance==null)
             {
                  instance = new TextureHolder();
             }
             return instance;
        }
