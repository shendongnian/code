             /*
             * startingDirection North 1, East 2, South 3, West 4
             * userDirection Left 1, Right 2, None 3
             *
             */ Works out the current position of the Rover
        public void currentLocation(int[,] grid, int direction,int row, int column, int move )
        {
            Scanner scanner = new Scanner();
            Messgae message = new Messgae();
            for (int i = 0; i <=5; i++)
            {
                switch (direction)
                {
                    case 1:
                        if (row - move >= 0 ) 
                        {
                            Console.WriteLine("\n Direction facing North, grid position " + grid.GetValue(row - move, column) + "\n");
                            row = row - move;
                            direction = currentDirection(scanner.getDirection(), 1);
                            move = scanner.getMove();
                            break;
                        }
                        else
                        {
                            message.endMessage();
                            i = 5;
                            break;
                        }
                    case 2:
                        if(column + move <= grid.Length) 
                        {
                            Console.WriteLine("\n Direction facing East, grid position " + grid.GetValue(row, column + move) + "\n");
                            direction = currentDirection(scanner.getDirection(), 2);
                            column = column + move;
                            move = scanner.getMove();
                            break;
                        }
                        else
                        {
                            message.endMessage();
                            i = 5;
                            break;
                        }
                    case 3:
                        if(row + move <= grid.Length)
                        {
                            Console.WriteLine("\n Direction facing South, grid position " + grid.GetValue(row + move, column) + "\n");
                            direction = currentDirection(scanner.getDirection(), 3);
                            row = row + move;
                            move = scanner.getMove();
                            break;
                        }
                        else
                        {
                            message.endMessage();
                            i = 5;
                            break;
                        }
                    case 4:
                        if (column - move >= 0)
                        {
                            Console.WriteLine("\n Direction facing West, grid position " + grid.GetValue(row, column - move) + "\n");
                            direction = currentDirection(scanner.getDirection(), 4);
                            column = column - move;
                            move = scanner.getMove();
                            break;
                        }
                        else
                        {
                            message.endMessage();
                            i = 5;
                            break;
                        }
                    default:
                        break;
                                
                }// End switch
            }// End for loop
        }// End currentLocation()
