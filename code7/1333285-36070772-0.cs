    for (int x = 0; x < texture.Width; x += texture.Width / nrPieces)
    {
        for (int y = 0; y < texture.Height; y += texture.Height / nrPieces)
        {
            Rectangle sourceRectangle = new Rectangle(x, y, texture.Width / _nrParticles, texture.Height / _nrParticles);
            Texture2D newTexture = new Texture2D(GameServices.GetService<GraphicsDevice>(), sourceRectangle.Width, sourceRectangle.Height);
            Color[] data = new Color[sourceRectangle.Width * sourceRectangle.Height];
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            newTexture.SetData(data);
    // TODO put new texture into an array
            }
        }
