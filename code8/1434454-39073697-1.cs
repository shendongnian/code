    List<List<double>> Temm = new List<List<double>>();
    for (int i = 0; i < A.Count; i++)
    {
        Temm[i] = new List<double>();
        for (int j = 0; j < A[i].Count; j++)
        {
            if (A[i][j] != 0) { Temm[i][j] = A[i][j]; }
            else { Temm[i][j] = Temm[i][j - 1]; }
        }
    }
