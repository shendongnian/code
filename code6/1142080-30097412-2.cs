        foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint point in StatChart.Series["Occurences"].Points)
        {
            foreach (KeyValuePair<string, int> pair in dictionary)
            {
                for (int idx = 0; idx < dicLength; idx++)
                {
                    point.SetValueXY(idx, pair.Value);
                    StatChart.Update();
                }
            }
        }
