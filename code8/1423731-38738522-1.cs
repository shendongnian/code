    for (int i = 0; i <= lengthA - 1; i++)
    {
        string s = tString[i];
        string[] words = s.Split(',');
        // here is the new row
        var row = dt.NewRow(); 
        for(int w = 0; w < words.Length; w++)
        {
            // set each column
            row[w] = words[w];     
        }
        // don't forget to add the Row to the Rows collection
        dt.Rows.Add(row);
    }
