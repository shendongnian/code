    String line;
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conStrtingName"].ConnectionString);
    conn.Open();
    StreamReader readFile = new StreamReader(filePath);
    SqlTransaction transaction = null;
    try
    {
        int counter = 0;
        while ((line = readFile.ReadLine()) != null)
        {
            string[] fields = line.Split('\t');
            if (fields.Length == 3)
            {
                DateTime date = Convert.ToDateTime(fields[0]);
                decimal txnCount = Convert.ToDecimal(fields[1]);
                string merchantName = fields[2];
                if (!string.IsNullOrEmpty(merchantName))
                {
                    long MerchantId = Array.IndexOf(Program.merchantArray, merchantName) + 1;
                    tables[workerId].Rows.Add(MerchantId, date, txnCount);
                    counter++;
                    if (counter % 100000 == 0)
                        Console.WriteLine("Worker: " + workerId + " - Transaction Records Read: " + counter);
                    if (counter % 1000000 == 0)
                    {
		                transaction = conn.BeginTransaction()
                        SqlBulkCopy copy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity, transaction);
                        copy.BulkCopyTimeout = 600;
                        copy.DestinationTableName = "Txn";
                        copy.WriteToServer(tables[workerId]);
                        transaction.Commit();
                        tables[workerId].Rows.Clear();
                        Console.WriteLine("Worker: " + workerId + " - Transaction Records Inserted: " + counter);
                    }
                }
            }
        }
        Console.WriteLine("Total Transaction Records Read: " + counter);
        if (tables[workerId].Rows.Count > 0)
        {
	        transaction = conn.BeginTransaction()
            SqlBulkCopy copy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity, transaction);
            copy.BulkCopyTimeout = 600;
            copy.DestinationTableName = "Txn";
            copy.WriteToServer(tables[workerId]);
            transaction.Commit();
            tables[workerId].Rows.Clear();
            Console.WriteLine("Worker: " + workerId + " - Transaction Records Inserted: " + counter);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        transaction.Rollback();
    }
    finally
    {
        conn.Close();
    }
