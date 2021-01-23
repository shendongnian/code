    using (var excel = new ExcelPackage(hpf.InputStream))
    {
    
        var ws = excel.Workbook.Worksheets["Sheet1"];
        int headerRow = 2;
        // hold the colum index based on the value in the header
        int col_cnst_mstr_id = 2;
        int col_cnst_prefix_nm = 4;
        // loop once over the columns to fetch the column index
        for (int col = ws.Dimension.Start.Column; col <= ws.Dimension.End.Column; col++)
        {
            if ("Existing Constituent Master Id".Equals(ws.Cells[headerRow, col].Value))
            {
                col_cnst_mstr_id = col;
            }
            if ("Prefix of the constituent(Mr, Mrs etc)".Equals(ws.Cells[headerRow, col].Value))
            {
                col_cnst_prefix_nm = col;
            }
        }
        //Read the file into memory
        // loop over all rows
        for (int rw = 4; rw <= ws.Dimension.End.Row; rw++)
        {
            // check if both values are not null
            if (ws.Cells[rw, col_cnst_mstr_id].Value != null &&
                ws.Cells[rw, col_cnst_prefix_nm].Value != null)
            {
                // the correct cell will be selcted based on the column index
                var gm = new GroupMembershipUploadInput
                {
                    cnst_mstr_id = (string) ws.Cells[rw, col_cnst_mstr_id].Value ?? String.Empty,
                    cnst_prefix_nm = (string) ws.Cells[rw, col_cnst_prefix_nm].Value ?? String.Empty
                };
    
                lgl.GroupMembershipUploadInputList.Add(gm);
            }
        }
    }
