    List<DetailTransaction > list = new List<DetailTransaction>();
   
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        DetailTransaction dt = new DetailTransaction();
        dt.TransactionID = labelID.Text;
        dt.ProductID = dataGridView1.Rows[i].Cells[0].Value.ToString();
        dt.Quantity = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
        list.Add(dt);
    }
    dc.DetailTransactions.InsertAllOnSubmit(list);
    dc.SubmitChanges();
