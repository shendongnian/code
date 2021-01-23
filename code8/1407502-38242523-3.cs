    int GetMaximumColumnWidth(DataGrid Grid, int ColumnIndex)
    {
        int maximum = 0;
        foreach(DataRow row in Grid.Rows)
        {
            string text = row.ItemArray[ColumnIndex];
            Size textSize = TextRenderer.MeasureText(text, Grid.Font);
            if(textSize.Width > maximum)
            {
                 maximum = textSize.Width;
            }
        }
        return maximum;
    } 
