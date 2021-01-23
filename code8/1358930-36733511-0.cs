    private static void ExecuteQuery(string connectionString, string query)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        DataTable output = null;
        while output is null
		{
			output = getDataFromDB(query);
		}
        if(output is DataTable && output.Rows.Count > 0)
        {
            Console.WriteLine("There are " + output.Rows.Count + " clusters within the capacity analysis.");
        }
    }
    private DataTable getDataFromDB(string query)
    {
        DataTable oDTResult = null;
        try
        {
            //create new SqlAdataAdapter
            SqlDataAdapter command = new SqlDataAdapter {SelectCommand = new SqlCommand(query, connection)};
            //connect to Sqldb
            connection.Open();
            //validate connection to database before executing query
            if (connection.State != ConnectionState.Open) return;
            Console.WriteLine("Connection successful\nExecuting query...");
            //set connection timeout
            command.SelectCommand.CommandTimeout = 200;
            //create new dataSet in order to input output of query to
            DataSet dataSet = new DataSet();
            //fill the dataSet
            command.Fill(dataSet, "capacity");
            DataTable dtTable1 = dataSet.Tables["capacity"];            
            oDTResult = dtTable1;
        }
        catch (Exception e)
        {
            Console.WriteLine("Unable to execute capacity (all records) query due to {0}", e.Message);
        }
        finally
        {
            connection.Close();
            Declarations.NumOfClusters = output.Rows.Count;
            Declarations.finalIssues = Issues(output, 2m, 20, true);
            Console.WriteLine("\n---------------Successfully Created Capacity DataSet---------------\n");
        }
        return oDTResult;
    }
