    int test = 0;
    for ( int lig = mat.GetLowerBound(0); lig <= mat.GetUpperBound(0); lig++ )
    {
        test++;
        for ( int col = mat.GetLowerBound(1); col <= mat.GetUpperBound(1); col++ )
            mat[lig, col] = test;
    }
