    Rectangle[,] gridRects = new Rectangle[row, col];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            gridRects[i,j] = new Rectangle(i * gridSize, j * gridSize, gridSize, gridSize);
        }
    }
