    for (var y = 0; y < layerHeight; y++)
    {
        for (var x = 0; x < layerWidth; x++)
        {
            var region = tile.Id == 0 ? null : _regions[tile.Id];
            if (region != null)
            {
                var tx = tile.X * _map.TileWidth;
                var ty = tile.Y * _map.TileHeight;
                var sourceRectangle = region.Bounds;
                var destinationRectangle = new Rectangle(tx, ty, region.Width, region.Height);
                _spriteBatch.Draw(region.Texture, destinationRectangle, sourceRectangle, Color.White);
            }
        }
    }
