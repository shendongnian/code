    /// <summary>
    /// Creates a new Sheet record in the database
    /// </summary>
    /// <param name="row">DataRow containing the Sheet record</param>
    public void CreateNewSheet(List<DataRow> rows)
    {
         var tempSheetsList = new List<Sheet>();
         foreach (var row in rows)
         {
             var sheetNo = row[SheetFields.Sheet_No.ToString()].ToString();
             if (string.IsNullOrWhiteSpace(sheetNo))
                  continue;
             var testPackNo = row[SheetFields.Test_Pack_No.ToString()].ToString();
             TestPack testPack = null;
             if (!string.IsNullOrWhiteSpace(testPackNo))
                  testPack = GetTestPackByTestPackNo(testPackNo);
                
             var existingSheet = GetSheetBySheetNo(sheetNo);
             if (existingSheet != null)
             {
                 UpdateSheet(existingSheet, row);
                 continue;
             }
    
             var isometricNo = GetIsometricNoFromSheetNo(sheetNo);
             var newSheet = new Sheet
             {
                 sheet_no = sheetNo,
                 isometric_no = isometricNo,
                 ped_rev = row[SheetFields.PED_Rev.ToString()].ToString(),
                 gpc_rev = row[SheetFields.GPC_Rev.ToString()].ToString()
             };
             if (testPack != null)
             {
                 newSheet.test_pack_id = testPack.id;
                 newSheet.test_pack_no = testPack.test_pack_no;
             }
             if (!tempSheetsList.Any(l => l.sheet_no == newSheet.sheet_no))
             {
                  DataStore.Context.Sheets.Add(newSheet);
                  tempSheetsList.Add(newSheet);
             }
       }
       try
       {
            DataStore.Context.SaveChanges();
            **DataStore.Dispose();** This is very important. Dispose the context
       }
       catch (DbEntityValidationException ex)
       {
           // Create log for the exception here
       }
    }
