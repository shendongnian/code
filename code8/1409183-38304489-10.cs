    int i = 0;
    for (int y = 0; y <= ySize; y++)
    {
        for (int x = 0; x <= xSize; x++)
        {
            for (int a = 0; a <= aSize; a++)
            {
                for (int b = 0; b <= bSize; b++)
                {
                    vertices[i] = new Vector3(x, y, a, b);
                    i++;
                }
            }
        }
    }
