    List<List<double>> B = new List<List<double>>();
    for (int i = 0; i < A.Count; i++)
    {
        List<double> innerResult = new List<double>();
        for (int j = 0; j < A[i].Count; j++)
        {
            if (A[i][j] != 0)
            {
                innerResult.Add(A[i][j]);
            }
            else
            {
                innerResult.Add(innerResult[j - 1]);
            }
        }
        B.Add(innerResult);
    }
