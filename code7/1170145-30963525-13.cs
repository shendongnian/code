    public static Texture2D Texture2D(string path)
    {
        Texture2D sprite = content.Load<Texture2D>(path);
        sprite.Name = path;
        return sprite;
    }
