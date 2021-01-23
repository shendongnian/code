    public Rectangle bound
        {
            get
            {
                return texture == null ? new Rectangle(0,0,0,0) : new Rectangle((int)position.X, (int)position.Y,
                    (int)(texture.Width * scale.X), (int)(texture.Height * scale.Y));
            }
        }
