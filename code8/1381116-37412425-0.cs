    while ((range.Cells[startpoint, cell] as Excel.Range) != null && (range.Cells[startpoint, cell] as Excel.Range).Value2 != null)
    {
        for (int i = 1; i <= numberOfColumns; i++)
        {
            string sValue = (range.Cells[startpoint, cell] as Excel.Range).Value2.ToString();
            stringList.Add(sValue);
            cell++;
        }
        startpoint++;
        cell = 1;
    }
