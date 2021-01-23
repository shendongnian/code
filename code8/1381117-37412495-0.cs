    try
    {
      while ((range.Cells[startpoint, cell] as Excel.Range).Value2.ToString() != null)
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
    }
    catch(nullBinderException)
    {
       //you find an empty cell
       //... break? jump over and continue?
       //... your logic...
    }
