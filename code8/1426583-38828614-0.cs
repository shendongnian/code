    // For each row in the DataTable...
    for (int i = 0; i < dataTable.Rows.Count; i++) {
        // Get record where number equals the DataTable's "number" column for this row
        // Then select the destroyed value:
        string sql = String.Format("SELECT * FROM Table WHERE number='{0}' THEN destroyed", dataTable.Rows[i]["number"].ToString());
        int destroyedCount = 0;
        // Execute the SQL query, return value to `destroyedCount`
        using (SqlConnection conn = new SqlConnection(connString))
        {
            SqlCommand cmd = new SqlCommand(sql);
            try 
            {
                conn.Open();
                destroyedCount = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // Set the table value to the SQL command's returned value
        dataTable.Rows[i]["destroyed"] = destroyedCount;
        // Assuming you want amount + destroyed = together
        int amountCount = 0;
        // Parse the table's current value for `amount`
        try 
        {
            amountCount = Int32.Parse(dataTable.Rows[i]["amount"]);
        }
        catch (ArgumentNullException argEx)
        {
            // Handle exception
        }
        catch (FormatException formatEx)
        {
            // Handle exception
        }
        // Set the `together` column to `amount` + `destroyed`
        dataTable.Rows[i]["together"] = (amountCount + destroyedCount).ToString();
    }
