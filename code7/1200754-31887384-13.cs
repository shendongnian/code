        static bool IsGameOver(ref int row, ref int col)
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (grid[r, c] == 0)
                    {
                        // set the row and col.
                        row = r;
                        col = c;
                        // but Lets check for the element with least possibilities in constraints.
                        // and prefer it against current row and col
                        int min = constraints[r, c].Count;
                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                if (constraints[i, j] != null && // if the constraint is available
                                    constraints[i, j].Count < min && // if found less possibilities
                                    grid[i, j] == 0) // if the element of the table is 0 (its not assigned yet)
                                {
                                    // set the row and col with less possibilities
                                    row = i;
                                    col = j;
                                    min = constraints[i, j].Count;
                                }
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
