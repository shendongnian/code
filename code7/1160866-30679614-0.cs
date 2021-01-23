    Button btnd = new Button();
    btnd.ID = "del" + reader[0];
    btnd.Text = "Borrar";
    TableCell cedit = new TableCell();
    cedit.ID = "edit" + reader[0];
    cedit.Controls.Add(btnd);
    //I previously created the row 'r'    
    r.Cells.Add(cedit);
    //I am inserting in Table2
    Table2.Rows.Add(r);
