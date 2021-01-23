    MouseState ms = Mouse.GetState();
    
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            if (gridRects.Contains(ms.X, ms.Y))
            {
                // Mouse is on gridCell[i,j]
            }
        }
    }
