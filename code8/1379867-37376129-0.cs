**Edit:** Another thought: you can create new variable called DrawPosition and use that variable when needed, instead of always substracting. That would look something like this:
    private Texture2D texture;
    public Vector2 position;
    public Vector2 DrawPosition
    { get { return position + new Vector2((int)(-texture.Width/2), -texture.Height); } }
Or, if you don't know C# that well (I do recommend looking it up), create a function that will return the DrawPosition()
    public Vector2 DrawPosition()
    {
        return position + new Vector2((int)(-texture.Width/2), -texture.Height); 
    }
