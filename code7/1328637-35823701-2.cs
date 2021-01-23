    //Declare 2d array
    int[,] x = new int[5][rs.FieldCount]; // 
    int i=0;
    
    for( int index = 0; index < rs.FieldCount; index ++ )
    {
        // usage
        x[i,index] = int.Parse(rs.GetString(index));
    }
