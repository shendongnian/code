    private void frmMain_Load(object sender, EventArgs e)
    {
        DataTable table = logic.ViewInfo(); // Combine declaration and assignment
        listView1.View = View.Details; // Better place it in designer 
        listView1.Columns.Clear();
        for (int i = 0; i < row.ItemArray.Length; i++)
        {
             listView1.Columns.Add("Column " + i.toString("D"));
        } 
 
        foreach (DataRow row in table.Rows)
        {
            ListViewItem myList = new ListViewItem(); // Move declaration into inner scope. You are reinitializing reference type variable each type. In my opinion, it is not good.
            for (int i = 0; i < row.ItemArray.Length; i++)
            {
                // You don't need Text property
                myList.SubItems.Add(row.ItemArray[i].ToString());
            }
            listView1.Items.Add(myList);
        }
    }
