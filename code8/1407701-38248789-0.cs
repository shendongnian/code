    private static void Main(string[] args)
    {
      try
      {
        const string connString =
          "Data Source=127.0.0.1,1433\\sqlexpress;Initial Catalog=dbfirealarm;Integrated Security=false;Pooling=False;User ID=admin;Password=admin;Connection Timeout=5";
        using (var conn = new SqlConnection(connString))
        {
          using (var adapter = new SqlDataAdapter("SELECT * FROM TABLE_LOGGING", conn))
          {
            using (var dataTable = new DataTable())
            {
              adapter.Fill(dataTable);
              PrintDataTable(dataTable);
            }
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }
    private static void PrintDataTable(DataTable table)
    {
      foreach (DataColumn column in table.Columns)
      {
        Console.Write("{0}\t", column.Caption);
      }
      Console.WriteLine();
      foreach (DataRow row in table.Rows)
      {
        foreach (var item in row.ItemArray)
        {
          Console.Write("{0}\t", item);
        }
        Console.WriteLine();
      }
    }
  }
