    // define this enum somewhere
    enum ColumPropEnum {
       cnst_mstr_id,  cnst_prefix_nm, ...
    }
    //define this prop somewhere
    Dictionary<int, ColumnPropEnum> colprops = new Dictionary<int, ColumnPropEnum>();
    //do this once before processing all rows
    for (int col = ws.Dimension.Start.Column; col <= ws.Dimension.End.Column; col++) {
        if (ws.Cells[headerRow, col].Value.ToString().Equals("Existing Constituent Master Id")) 
            colprops.Add(col, ColumnPropEnum.cnst_mstr_id);
        else if (ws.Cells[headerRow, col].Value.ToString().Equals(" ..."))
            colprops.Add(col, ColumnPropEnum.cnst_prefix_nm);
        ...
    }
    //now use this dictionary in each row    
    for (int rw = 4; rw <= ws.Dimension.End.Row; rw++)
    {
    ....
        for (int col = ws.Dimension.Start.Column; col <= ws.Dimension.End.Column; col++) {
            
            //the single ? checks, whether the Value is null, if yes it returns null, otherwise it returns ToString(). Then the double ?? checks whether the result if the operation is null, if yes, it assigns "" to s, otherwise the result of ToString(); 
            var s = ws.Cells[rw, col].Value?.ToString() ?? "";
            ColumnPropEnum cp;
            if (colpros.TryGetValue(col, out cp)) {
                switch (cp) {
                    case cnst_mstr_id: gm.cnst_mstr_id = s; break;
                    case cnst_prefix_nm: gm.cnst_prefix_nm = s; break;
                    ...
                }
            }
        }
