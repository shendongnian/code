    List<List<List<List<string>>>> List4D = new List<List<List<List<string>>>>();
    int i1 = 2, i2 = 3, i3 = 0;
    for (int i = 0; i <= Math.Max(i1, 1); i++)
        List4D.Add(new List<List<List<string>>>());
    for (int i = 0; i <= Math.Max(i2, 1); i++)
        List4D[i1].Add(new List<List<string>>());
    for (int i = 0; i <= Math.Max(i3, 1); i++)
        List4D[i1][i2].Add(new List<string>());
    List4D[i1][i2][i3].Add("test");
