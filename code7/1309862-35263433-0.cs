        public static int[] Evaluate(List<int[]> futures, Board chessBoard)
        {
            int[] bestMove = new int[5];
            Random rndMove = new Random();
            Array.Copy(futures[rndMove.Next(futures.Count)], bestMove, 5);
            if (chessBoard.Depth() == toDepth)
            {
                if (chessBoard.IsTurn())
                {
                    // Maximum
                    //bestMove[4] = -1000000;
                    foreach (int[] move in futures)
                    {
                        if (move[4] > bestMove[4])
                        {
                            Array.Copy(move, bestMove, 5);
                        }
                    }
                }
                else
                {
                    // Minimum
                    //bestMove[4] = 1000000;
                    foreach (int[] move in futures)
                    {
                        if (move[4] < bestMove[4])
                        {
                            Array.Copy(move, bestMove, 5);
                        }
                    }
                }
            }
            else
            {
                if (chessBoard.IsTurn())
                {
                    // Maximum
                    //bestMove[4] = -1000000;
                    foreach (int[] move in futures)
                    {
                        if (Math.Abs(chessBoard.Pieces()[move[3], move[2]]) == king) return move;
                        Board newBoard = MoveToBoard(move, chessBoard);
                        move[4] += Evaluate(CalcFutures(newBoard), newBoard)[4];
                        if (move[4] > bestMove[4])
                        {
                            Array.Copy(move, bestMove, 5);
                        }
                    }
                }
                else
                {
                    // Minimum
                    //bestMove[4] = 1000000;
                    foreach (int[] move in futures)
                    {
                        if (Math.Abs(chessBoard.Pieces()[move[3], move[2]]) == king) return move;
                        Board newBoard = MoveToBoard(move, chessBoard);
                        move[4] += Evaluate(CalcFutures(newBoard), newBoard)[4];
                        if (move[4] < bestMove[4])
                        {
                            Array.Copy(move, bestMove, 5);
                        }
                    }
                }
            }
            //Console.WriteLine(bestMove[4]);
            return bestMove;
        }
