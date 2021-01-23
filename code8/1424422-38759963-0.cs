    static void Main(string[] args)
    {
         var insert1 = DataTableBulkInsert(DataTable1);
         var insert2 = DataTableBulkInsert(DataTable2);
         Task.WaitAll( insert1, insert2);
    }
    
    public static async Task DataTableBulkInsert(DataTable Table)
    {
          using(var localConnection = new SqlConnection(/* connection string */))
          {
              SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(localConnection );
              sqlBulkCopy.DestinationTableName = "dbo.DatabaseTable";
              localConnection.Open();                    
              return await sqlBulkCopy.WriteToServerAsync(Table);
          }
     }
