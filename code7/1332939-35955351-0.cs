    var adapter = new TestTableAdapter();
    adapter.Adapter.RowUpdating += 
       new System.Data.OleDb.OleDbRowUpdatingEventHandler((sender, e) =>
        {
          // UPDATE [Test] SET [Price] = {{Price}} WHERE [ID] = @id
          // {{Price}} is a fake parameter to be replaced by custom code
          e.Command.CommandText = e.Command.CommandText.Replace("{{Price}}", 
                     string.Format(new System.Globalization.CultureInfo("en-US"),
                     "{0:#0.00}", 
                     e.Row["Price"])); 
         }
       );
    ConsoleApplication2.SampleDataSet.TestDataTable table = adapter.GetData();
    table[0].Price = 1.23m;
    adapter.Update(table[0]);
