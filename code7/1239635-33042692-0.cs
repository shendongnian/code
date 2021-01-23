    try
    {
           newDuration = (DateTime)row.GetCellValue(3);
    }
    catch
    {
           row.SetCellValue(3, new DateTime());
           newDuration = (DateTime)row.GetCellValue(3);
    }
