    for(int i = 0; i < itemsnumber; i++){
        TableRow tr = new TableRow();
        TableCell tc1 = new TableCell();
        TableCell tc2 = new TableCell();
        tc1.Controls.Add(new LiteralControl("<span>" + List1[i].ToString() + "</span>"));
        tc2.Controls.Add(new LiteralControl("<span>" + List2[i].ToString() + "</span>"));
        tr.Controls.Add(tc1);
        tr.Controls.Add(tc2);
        Table1.Controls.Add(tr);
    }
