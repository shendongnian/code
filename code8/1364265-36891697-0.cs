    foreach (var table in new [] {tbl0, tbl1, tbl2, tbl3, tbl4}) {
        foreach (DataRow dr in table.Rows) {         
            string TABLENAME = "tbl"+i; 
    
            TableHeaderRow tHRow = new TableHeaderRow();
            TableHeaderCell tHeader = new TableHeaderCell();
            tHeader.Text = dr.Field<string>("Loc");
            tHRow.Cells.Add(tHeader);
    
            (Table)this.FindControl(TABLENAME).Rows.Add(tHRow);
    
            //fill 'hl' with sql
    
            tCell.Controls.Add(hl);
            tRow.Controls.Add(tCell);
    
            (Table)this.FindControl(TABLENAME).Rows.Add(tRow);
            i++;
        }
    }
