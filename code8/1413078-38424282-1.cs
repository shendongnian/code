    List<string[]> data = new List<string[]>();
    using (StringReader sr = new StringReader(csvText))
    {
        while (sr.Peek() > 0)
        {
            data.Add(sr.ReadLine().Split(','));
        }
    }
    //Iterates through columns, skipping first one (names)
    List<string> output = new List<string>();
    for (int i = 1; i < data[0].Count(); i++)
    {
        string subjectName = data[0][i];
        Dictionary<string,int> grades = new Dictionary<string, int>();
        //Iterates through rows, skipping first one (headers)
        for (int j = 1; j < data.Count; j++)
        {
            grades.Add(data[j][0],Convert.ToInt32(data[i][j]));
        }
        output.Add(subjectName + " - " + grades.Aggregate((l, r) => l.Value > r.Value ? l : r).Key);
    }
