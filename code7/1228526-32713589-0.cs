    int row, col;
         row = col = 2;
         int j;
         char[] ch = new char[ row * col + row ];
         for( int i = 0; i < 2; i++ ) {
            for( j = 0; j < 2; j++ ) {
               ch[ i * col + (j+i) ] = 'a';
               //Console.Write(ch[ i * col + j ]);
            }
            ch[ i * col + (j+i) ] = '\n';
            //Console.Write(ch[ i * col + j ]);
         }
         Console.WriteLine("Character Array:");
         foreach( char c in ch ) {
            Console.Write(c);
         }
