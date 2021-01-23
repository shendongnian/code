            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (playerX == i && playerY == j)
                    {
                        DrawPlayer();
                    }
                    else
                    {
                        DrawCell(map[i][j]);
                    }
                }
            }
