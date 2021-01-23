    List<Rectangle> list = new List<Rectangle>();
    int maxWidth = 300;
    int maxHeight = 200;
    int x = 0;
    int y = 0;
    while (list.Count < 20)
    {
        for (x = 0; x < maxWidth; x += (maxWidth / 5))
        {
            for (y = 0; y < maxHeight; y += (maxHeight / 4))
            {
                list.Add(new Rectangle(x, y, (maxWidth / 5), (maxHeight / 4));
            }
            y = 0;
        }
        x = 0;
    }
