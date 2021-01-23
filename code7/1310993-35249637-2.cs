    for ( int lig = mat.GetLowerBound(0); lig <= mat.GetUpperBound(0); lig++ )
    {
        for ( int col = mat.GetLowerBound(1); col <= mat.GetUpperBound(1); col++ )
            mat[lig, col] = lig + 1;
    }
