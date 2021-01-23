    public void ModifyData()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var tlis = GetTlis(connection).ToList();
            connection.Open();
    
            Quotes quotes;
            BillOfLading billOfLading;
    
            using (var trans = connection.BeginTransaction())
            {
                quotes = GetQuotesByTli(connection, transaction, tli);
    
                billOfLading = GetBillOfLadings(connection, transaction, tli);
            }
        }
    
        // Process those items retrieved from the database.
        var processedItems = this.Process(/* the items that you want to process */);
    
        using (var connection = new SqlConnection(connectionString))
        {
            var tlis = GetTlis(connection).ToList();
            connection.Open();
    
            using (var trans = connection.BeginTransaction())
            {
                // do all your inserts.
            }
        }
    }
