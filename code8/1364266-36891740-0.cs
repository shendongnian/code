    var tables = new List<Table>();
    tables.Add(tbl0);
    tables.Add(tbl1);
    tables.Add(tbl2);
    tables.Add(tbl3);
    tables.Add(tbl4);
    foreach(var tbl in tables)
    {
	   foreach (DataRow dr in dtTable.Rows)
       {   
		   TableHeaderRow tHRow = new TableHeaderRow();
		   TableHeaderCell tHeader = new TableHeaderCell();
		   tHeader.Text = dr.Field<string>("Loc");
		   tHRow.Cells.Add(tHeader);
		   tbl.Rows.Add(tHRow);
		   //fill 'hl' with sql
		   tCell.Controls.Add(hl);
		   tRow.Controls.Add(tCell);
		   tbl.Rows.Add(tRow);   
       }}
