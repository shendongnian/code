    int row = 0;
    int col = 0;
    int[ , ] matrix1;
    int row = 0;
    int col = 0;
    int[ , ] matrix1;
    row = Convert.ToInt16( Console.ReadLine( ) );
    col = Convert.ToInt16( Console.ReadLine( ) );
    matrix1 = new int[ row, col ];
    Console.WriteLine( "enter the numbers" );
    try
    {
    for ( int i = 0; i < row; i++ )
    {
        for ( int j = 0; j < col; j++ )
        {
       matrix1[ i, j ] = Convert.ToInt16( Console.ReadLine( ) );
      }
    }
     }
      catch(Exception e)
     {
      Console.WriteLine("You Have entered invalid character");
    }
    
