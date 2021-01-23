    enum FieldElement
    {
       Free, X, At, Boarder
    }    
    
    class Board
    {
        public FieldElement[,] Field {get; set;}
        public static Board ParseBoard(string board)
        {
            string[] lines = board.Split("\n");
            var field = new FieldElement[lines[0].Length, lines.Length]; 
            for(int y=0; y < lines.Length; y++)
            {
                 for(int x=0; x < lines[y].Length; x++)
                 {
                     switch(lines[y][x]) //that's a char
                     {
                         case 'X': 
                            field[x,y] = FieldElement.X; break;
                         case '|':
                         case '-':
                         case '.':
                         case '\'':
                            field[x,y] = FieldElememt.Boarder; break;
                         case ' ':
                            field[x,y] = FieldElement.Free; break;
                         case '@': 
                            field[x,y] = FieldElement.At; break;
                         default: 
                            Console.WriteLine($"Unrecognized character {lines[y][x]} in line {y} at position {x}");
                     }
                 }
            }
            return new Board() { Field = field; };
        }
    }
