    for (int i = 0; i < dataGridView1.RowCount; i++)
    {
        //Add items in the listview
        string[] arr = new string[2];
        ListViewItem itm;
    
        //Add first item
        arr[0] = dataGridView1.Rows[i+1].Cells["F1"].Value.ToString();
        arr[1] = "Send";
        itm = new ListViewItem(arr);
        listView1.Items.Add(itm);
    
    }
