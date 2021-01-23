        Series S = StatChart.Series["Occurences"];
        foreach (KeyValuePair<string, int> pair in dictionary)
        {
            for (int idx = 0; idx < dicLength; idx++)
            {
                S.Points.AddXY(idx, pair.Value);
                 
            }
        }
