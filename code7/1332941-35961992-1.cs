    var adapter = new TestTableAdapter();
    adapter.Adapter.RowUpdating += new System.Data.OleDb.OleDbRowUpdatingEventHandler(
       (sender, e) =>
       {
         foreach (System.Data.OleDb.OleDbParameter parameter in e.Command.Parameters)
              if (parameter.DbType == System.Data.DbType.Decimal)
                  parameter.OleDbType = System.Data.OleDb.OleDbType.Currency;
       }
    );
    ConsoleApplication2.SampleDataSet.TestDataTable table = adapter.GetData();
    table[0].Price = 3.75m;
    adapter.Update(table[0]);
