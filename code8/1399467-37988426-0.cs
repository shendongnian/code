    Table tblEmployeeList = new Table();
    foreach (DataRow row in dtEmployList.Rows)
    {
            TableRow tRow = new TableRow();
            foreach(DataColumn dCol in dtEmployList.Columns)
            {
                TableCell tCell = new TableCell();
                tCell.Text = row["Username"].ToString();
                tRow.Cells.Add(tCell);
            }
 
            tblEmployeeList.Rows.Add(tRow);
     }
    div1.Controls.Add(tblEmployeeList); //This will show the table in the page
