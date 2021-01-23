    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        var content = new XNBContentManager(_xnbStream, this.GraphicsDevice);
        myModel = content.Load<Model>("WhateverName");
    }
