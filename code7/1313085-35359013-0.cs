    int batchSize = 1024; // define this elsewhere
    // allValuesToDel is your list of values. I've just defined it as an empty list
    var allValuesToDel = new List<int>();
    var valueErrors = new List<int>();
    for (int i = 0; i < allValuesToDel.Count; i += batchSize)
    {
        using (var sc = new SqlConnection(dbConnString))
        {
            sc.Open();
            var valueBatch = allValuesToDel.Skip(i)
                .Take(batchSize)
                // annotating each value with a 'processed' flag allows us to track them
                .Select(k => new { Value = k, Processed = false }).ToList();
                
            // the starting window size
            int windowSize = valueBatch.Count;
            while (valueBatch.Count > 0 && valueBatch.Any(o => !o.Processed))
            {
                // get the unprocessed values within the window
                var valuesToDel = valueBatch.Where(k => !k.Processed).Take(windowSize).ToList();
                string nosConcat = string.Join(",", valuesToDel.Select(k => k.Value));
                try
                {
                    using (var cmd = sc.CreateCommand())
                    {
                        cmd.CommandText = string.Format("DELETE FROM {0} WHERE {1} IN ({2})", tblName, delColumnName, nosConcat); 
                        cmd.ExecuteNonQuery();
                    }
                    
                    // on success we can mark them as processed
                    valuesToDel.ForEach(k => k.Processed = true);
                    
                    // Since delete worked, let's try on more records
                    windowSize = windowSize * 2;
                }
                catch (SqlException ex)
                {
                    if (windowSize == 1)
                    {
                        // we found a value that failed - add that to the list of failures
                        valueErrors.Add(valuesToDel[0].Value);
                        valuesToDel.ForEach(k => k.Processed = true); // mark it as processed
                    }
                    
                    // decrease the window size (until 1) to try and catch the problematic record
                    windowSize = (windowSize / 2) + 1;
                }
            }
        }
    }
    
