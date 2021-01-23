    private string CreateInsertSQL(ListViewItemCollection listView) {
       StringBuilder insertSQL = new StringBuilder("INSERT INTO SALES_TABLE(pay_type, pay_amount) VALUES ");
       foreach(ListViewItem item in listView.Items)
       {
           insertSQL.AppendFormat("({0}, {1}),", item.SubItems.First(), item.SubItems.Last());
       }
       insertSQL.Remove(insertSQL.Length - 1, 1);
       return insertSQL.ToString();
    }
