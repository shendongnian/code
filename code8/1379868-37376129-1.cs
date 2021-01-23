**Edit:** Another thought: you can create new variable called DrawPosition and use that variable when needed, instead of always substracting. That would look something like this:
    private Texture2D texture;
    public Vector2 position;
    public Vector2 DrawPosition
    { get { return position + new Vector2(-texture.Width/2, -texture.Height); } }
    public void Draw(SpriteBatch spriteBatch)
    { spriteBatch.Draw(texture, DrawPosition, Color.White); }
Or, if this new variable doesn't make scence to you, create a function that will return the DrawPosition()
    public Vector2 DrawPosition()
    { return position + new Vector2(-texture.Width/2, -texture.Height); }
