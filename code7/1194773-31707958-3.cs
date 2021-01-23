    private string CreateInsertSQL(ListView view) {
       StringBuilder insertSQL = new StringBuilder("INSERT INTO SALES_TABLE(pay_type, pay_amount) VALUES ");
       foreach(ListViewItem item in view.Items)
       {
           insertSQL.AppendFormat("({0}, {1}),", item.SubItems.First(), item.SubItems.Last());
       }
       insertSQL.Remove(insertSQL.Length - 1, 1);
       return insertSQL.ToString();
    }
