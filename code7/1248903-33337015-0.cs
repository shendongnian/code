        var newPic = TransformedPic.Clone(); // Clone your pic to a new object. 
        int Height = TransformedPic.GetLength(0);
        int Width = TransformedPic.GetLength(1);
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width / 2; j++)
            {
                newPic[i, j] = TransformedPic[i, ((Width) - (j + 1))];
            }
        }
        TransformedPic = newPic;
