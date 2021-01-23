    SpriteBatch spriteBatch = new SpriteBatch(graphics);
            spriteBatch.Begin();
    foreach (Color pixel in colors)
        {
            
    
            if (pixel == brickRGB)
            {
                Texture2D brick = Content.Load<Texture2D>("blocks/brick");
                spriteBatch.Draw(brick, new Rectangle(placeX, placeY, 40, 40), Color.White);
    
                Rectangle rect = new Rectangle(placeX, placeY, 40, 40);
                blocks.Add(rect);
            }
            else if (pixel == blankRGB)
            {
                Texture2D back = Content.Load<Texture2D>("titlescreen/back");
                spriteBatch.Draw(back, new Rectangle(placeX, placeY, 40, 40), Color.White);
            }
    
            if (placeX == 840)
            {
                placeX = 0;
                placeY += 40;
            }
            else placeX += 40;
            
        }
    spriteBatch.End();
