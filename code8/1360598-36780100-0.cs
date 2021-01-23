    public int CheckArea(int cordX, int cordY)
    {
        int count = 0;
        int fieldWidth = tileField.GetLength(1);
        int fieldHeight = tileField.GetLength(0);
        
        // Check for the neighbor to the North
        if(cordY != 0)
        {
            count += GetValueAtCoordinate(cordX,cordY - 1);
        }
        // Check for the neighbor to the East
        if (cordX < fieldWidth - 1)
        {
            count += GetValueAtCoordinate(cordX + 1, cordY);
            
            // NE neighbor
            if(cordY != 0)
            {
                count += GetValueAtCoordinate(cordX - 1, cordY - 1);
            }
            
            // SE neighbor
            if(cordY != fieldWidth - 1)
            {
                count += GetValueAtCoordinate(cordX - 1, cordY + 1);
            }
        }
        // Check for the neighbor to the South
        if (cordY < fieldHeight - 1)
        {
            count += GetValueAtCoordinate(cordX, cordY + 1);
        }
        // Check for the neighbor to the West
        if (cordX != 0)
        {
            count += GetValueAtCoordinate(cordX - 1, cordY);
            
            // NW neighbor
            if(cordY != 0)
            {
                count += GetValueAtCoordinate(cordX - 1, cordY - 1);
            }
            
            // SW neighbor
            if(cordY != fieldHeight - 1)
            {
                count += GetValueAtCoordinate(cordX - 1, cordY + 1);
            }
        }
    
        return count;
    }
    
    public int GetValueAtCoordinate(int x, int y)
    {
        return tileField[x,y] == true ? 1 : 0;
    }
