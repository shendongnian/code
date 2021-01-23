    DataTable dt = new DataTable();
    dt.Columns.Add("A0_1", typeof(double));
    dt.Columns.Add("A0_2", typeof(double));
    dt.Columns.Add("B0_1", typeof(double));
    dt.Columns.Add("B0_2", typeof(double));
    
    dt.Rows.Add(4.0, 10.0, 2.0, 2.0);
    dt.Rows.Add(20.0, 30.0, 10.0, 5.0);
    
    double[] resultsFirst = new double[dt.Rows.Count];
    double[] resultsSecond = new double[dt.Rows.Count];
    
    int index = 0;
    foreach (DataRow r in dt.Rows)
    {
        resultsFirst[index] = r.Field<double>("A0_1") / r.Field<double>("B0_2");
        resultsSecond[index] = r.Field<double>("A0_2") / r.Field<double>("B0_1");
        index++;
    }
    
    for (int i = 0; i < resultsFirst.Length; i++)
    {
        Console.WriteLine($"First = { resultsFirst[i] } ** Second = { resultsSecond[i] }");
    }
