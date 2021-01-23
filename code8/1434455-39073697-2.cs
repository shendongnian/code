    List<List<double>> Temm = new List<List<double>>();
    for (int i = 0; i < A.Count; i++)
    {
        Temm.Add(new List<double>());
        for (int j = 0; j < A[i].Count; j++)
        {
            double temmValue;
            if (A[i][j] != 0) { temmValue = A[i][j]; }
            else { temmValue = Temm[i][j - 1]; }
            Temm[i].Add(temmValue)
        }
    }
