    using (var stream = TitleContainer.OpenStream(path2))
            {
                spriteSheet2 = Texture2D.FromStream(graphicsDevice, stream);
            }
            currSprite = 2;
           
        //try change y += 32 + 2 and x += 32 + 2 forthis x += 32 + 1 // y += 32 + 1
        for (int y = 0; y < spriteSheet2.Height; y += 32 + 2)
        {
            for (int x = 0; x < spriteSheet2.Width; x += 32 + 2)
            {
                  //and this if the first comment dont work in the next line you add a new rectangle. change the values new Rectangle(x, y, 31, 31) 
                objects[currSprite].Add(new Rectangle(x, y, 32, 32));
            }
        }
        using (var stream = TitleContainer.OpenStream("Content/x.png"))
        {
            test = Texture2D.FromStream(graphicsDevice, stream);
        }
