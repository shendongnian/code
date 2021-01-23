    private static void AdapterUpdate(string connectionString)
    {
        using (SqlConnection connection =
               new SqlConnection(connectionString))
    {
        SqlDataAdapter dataAdpater = new SqlDataAdapter(
          "SELECT CategoryID, CategoryName FROM Categories",
          connection);
        dataAdpater.UpdateCommand = new SqlCommand(
           "UPDATE Categories SET CategoryName = @CategoryName " +
           "WHERE CategoryID = @CategoryID", connection);
        dataAdpater.UpdateCommand.Parameters.Add(
           "@CategoryName", SqlDbType.NVarChar, 15, "CategoryName");
        SqlParameter parameter = dataAdpater.UpdateCommand.Parameters.Add(
          "@CategoryID", SqlDbType.Int);
        parameter.SourceColumn = "CategoryID";
        parameter.SourceVersion = DataRowVersion.Original;
        DataTable categoryTable = new DataTable();
        dataAdpater.Fill(categoryTable);
        DataRow categoryRow = categoryTable.Rows[0];
        categoryRow["CategoryName"] = "New Beverages";
        dataAdpater.Update(categoryTable);
        Console.WriteLine("Rows after update.");
        foreach (DataRow row in categoryTable.Rows)
        {
            {
                Console.WriteLine("{0}: {1}", row[0], row[1]);
            }
        }
    }
    }
