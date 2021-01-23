    foreach (AllCasesReplies infoList in allCasesReplies)
      {
          n = 0;
          Microsoft.Office.Interop.Excel.Range range1 = mWorkSheet.Cells[l + m, ++n] as Range;
          range1.TextFormat = "";
          range1.Value2 = infoList.id;
    
          Microsoft.Office.Interop.Excel.Range range2 = mWorkSheet.Cells[l + m, ++n] as Range;
          range2.TextFormat = "";
          range2.Value2 = infoList.replies;
          m++;
       }
