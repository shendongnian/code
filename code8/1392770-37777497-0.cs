    tableLayoutPanel1.RowCount = messagesTable.Rows.Count;
    
    foreach (DataRow row in messagesTable.Rows)
    {
        CheckBox ck = new CheckBox();
        ck.Text = row[1].ToString();
        tableLayoutPanel1.Controls.Add(ck);
        tableLayoutPanel1.SetRow(ck, i++);
    }
