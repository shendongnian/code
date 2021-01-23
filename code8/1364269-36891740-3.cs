    int i = 0;
    var tables = new List<Table>();
    tables.Add(tbl0);
    tables.Add(tbl1);
    tables.Add(tbl2);
    tables.Add(tbl3);
    tables.Add(tbl4);
    
	foreach (DataRow dr in dtTable.Rows)
    {   
        // validation
       if(i>tables.Count)
       {
          return;
       }
       var tbl in tables[i];
	   TableHeaderRow tHRow = new TableHeaderRow();
	   TableHeaderCell tHeader = new TableHeaderCell();
	   tHeader.Text = dr.Field<string>("Loc");
	   tHRow.Cells.Add(tHeader);
	   tbl.Rows.Add(tHRow);
	   //fill 'hl' with sql
	   tCell.Controls.Add(hl);
	   tRow.Controls.Add(tCell);
	   tbl.Rows.Add(tRow);
       i++;
    }
