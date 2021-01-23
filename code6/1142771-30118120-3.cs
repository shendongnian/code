    for(int i = 1; i <=20; i++)
    {
       excelRange = (Excel.Range)excelWorkSheet.Cells[i, 1];
       if (!string.IsNullOrEmpty(excelRange.Text.ToString()))
       {
           ((Range)excelWorkSheet.Rows[i]).Delete(excelRange);
       }
    }
