    public static Vector JacobiMethod(Matrix inputMatrix, Vector expectedOutcome, int iterations)
    {
        Vector solvedVector = new Vector(Enumerable.Repeat(0.0, expectedOutcome.vectorValues.Length).ToArray());
        for(int p = 0; p < iterations; p++)
        {
            for (int i = 0; i < inputMatrix.RowCount; i++)
            {
                double sigma = 0;
                for (int j = 0; j < inputMatrix.ColumnCount; j++)
                {
                    if (j != i)
                        sigma += inputMatrix._matrix[i][j] * solvedVector.vectorValues[j];
                }
                solvedVector.vectorValues[i] = (expectedOutcome.vectorValues[i] - sigma) / inputMatrix._matrix[i][i];
            }
            Console.WriteLine("Step #" + p + ": " + String.Join(", ", solvedVector.vectorValues.Select(v => v.ToString()).ToArray()));
        }
        return solvedVector;
    }
    
