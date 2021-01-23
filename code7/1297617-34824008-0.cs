    int row = 0;
    int col = 0;
    int[ , ] matrix1;
            
    row = Convert.ToInt16( Console.ReadLine( ) );
    col = Convert.ToInt16( Console.ReadLine( ) );
    matrix1 = new int[ row, col ];
    Console.WriteLine( "enter the numbers" );
    for ( int i = 0; i < col; i++ )
    {
        for ( int j = 0; j < row; j++ )
        {
            matrix1[ i, j ] = Convert.ToInt16( Console.ReadLine( ) );
        }
    }
