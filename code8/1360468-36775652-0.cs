    int n = 4;
    List<string> matrix = new List<string>();
    for (int i = 0; i < Math.Pow(2, n); i++)
    {
        matrix.Add(Convert.ToString(i, 2).PadLeft(n, '0'));
    }
