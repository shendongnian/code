    _regions = new Dictionary<int, TextureRegion2D>();
    for (var y = Margin; y < texture.Height - Margin; y += TileHeight + Spacing)
    {
        for (var x = Margin; x < texture.Width - Margin; x += TileWidth + Spacing)
        {
            _regions.Add(id, new TextureRegion2D(Texture, x, y, TileWidth, TileHeight));
            id++;
        }
    }
