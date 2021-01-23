    int[,] NN = new int[3,6] {{1, 2, 3, 4, 5, 6 }, {2, 5, 6, 3, 1, 0}, {0, 9, 2, 6, 7, 8}};
    
                string[] lines = new string[NN.GetLength(1)];
                for (int i = 0; i < NN.GetLength(0); ++i)
                {
                    for (int j = 0; j < NN.GetLength(1); ++j)
                    {
                        lines[j] += NN[i,j] + ((i == NN.GetLength(0) - 1) ? "" : ",");
                    }
                }
                File.WriteAllLines("path.csv", lines); 
