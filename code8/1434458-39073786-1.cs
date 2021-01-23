        List<List<double>> A = new List<List<double>>()
        {
            new List<double>() { 1, 0, 0 },
            new List<double>() { 1, -1, 0 }
        };    
    
        List<List<double>> Temm = new List<List<double>>(A.Count);
        for (int i = 0; i < A.Count; i++)
        {
            Temm.Insert(i,new List<double>());
            for (int j = 0; j < A[i].Count; j++)
            {
                if (A[i][j] != 0) { Temm[i].Insert(j,A[i][j]); }
                else { Temm[i].Insert(j,Temm[i][j - 1]); }
            }
        }
