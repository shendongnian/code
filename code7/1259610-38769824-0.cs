    public void GenerateHeightMap() 
    {
      for (int z = 0; z < zRes; z++) 
      {
        //         ratio                    annotation1          annotation2
        var zCoord=((float)z/(float)zRes) + (position.z/size.z)*((zRes-1)/zRes); // place the zCoord here so the calculation won't be repeated (zRes-1) times
        for (int x = 0; x < xRes; x++) 
        {
          var xCoord=((float)x/(float)xRes) + (position.x/size.x)*((xRes-1)/xRes);
          var value = settings.GetModule().GetValue(xCoord, zCoord, 0);
          heights[x, z] = (float)(value / 2f) + 0.5f;
        }
      }
    }
