    //Declare 2d array
    int[,] x = new int[5][rs.FieldCount]; // 
    int i=0;
    
    for( int index = 0; index < rs.FieldCount; index ++ )
    {
        int validInt;
        if(int.TryParse(rs.GetString(index), out validInt)
        {
            // usage
            x[i,index] = validInt;
        }
        else { x[i,index] = -1; //default value
        } 
    }
