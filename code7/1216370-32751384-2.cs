    foreach (var detailRow in detailSheet.Rows)
    {
         long rowId = (detailRow.Id.HasValue) ? detailRow.Id.Value : 0;
         long parentId = (detailRow.ParentId.HasValue) ? detailRow.ParentId.Value : 0;
    
         int parentRowNumber = 0;
         int level = 0;
    
         if (parentId != 0)
         {
             foreach (RowLevel lvl in rowLevelList)
             {
                 if (lvl.RowId != parentId) continue;
    
                 parentRowNumber = lvl.Row;
                 level = lvl.Level + 1;
                 break;
             }
         }
         RowLevel rowLevel = new RowLevel();
         rowLevel.RowId = rowId;
         rowLevel.ParentId = parentId;
         rowLevel.Row = detailRow.RowNumber.Value;
         rowLevel.ParentRowNumber = parentRowNumber;
         rowLevel.Level = level;
         rowLevelList.Add(rowLevel);
         System.Diagnostics.Debug.WriteLine("Row: " + detailRow.RowNumber);
         System.Diagnostics.Debug.WriteLine("Row Id: " + rowId);
         System.Diagnostics.Debug.WriteLine("Parent Id: " + parentId);
         System.Diagnostics.Debug.WriteLine("Parent Row Number: " + parentRowNumber);
         System.Diagnostics.Debug.WriteLine("Level: " + level);
         System.Diagnostics.Debug.WriteLine("");
    }
    
