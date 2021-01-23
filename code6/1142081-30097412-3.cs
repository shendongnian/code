        Series S = StatChart.Series["Occurences"];
        for (int idx = 0; idx < dicLength; idx++)
        {
            KeyValuePair<string, int> pair = dictionary.ElementAt(idx);
            S.Points.AddXY(idx, pair.Value);
            S.Points[idx].ToolTip = pair.Key;  // optional tooltip
        }
