    foreach (DataRow objectrow in ds.Tables["Object"].Rows)
    {
        myTableCell = new TableCell();
        CheckBox cb = new CheckBox();
        //Add unique id to each checkbox...
        cb.Attributes.Add("id",objectrow["id"].ToString());
        myTableCell.Controls.Add(cb);
        myTableRow.Cells.Add(myTableCell);
    }
