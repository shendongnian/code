    char[] chars = new char[3] { 'a', 'b', 'c'};
    for (int k = 0; k < chars.Length; k++)
    {
       var c = chars[k];
        for (int m = 1; m <= 4; m++)
        {
            dt.Columns.Add("Name" + "_" + c + m);
            dt.Columns.Add("Class" + "_" + c + m);
            dt.Columns.Add("Score" + "_" + c + m);
        }
    }
