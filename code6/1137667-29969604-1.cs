    // asuming you want row 0
    int row = 0;
    // this give to g the size of the row of gameObjectData
    int[] g = new int[gameObjectData.getLenght(row)];
    for (int i = 0; i < gameObjectData.getLenght(row); i++)
    {
       g[i] = gameObjectData[row,i];
    }
