    /// List<RemoteReadings> contains a list of database Entity Classes RemoteReadings 
            public List<RemoteReadings> removeDublicatesFirst(List<RemoteReadings> lst)
            {
    
                try
                {
    
                    DataClasses1DataContext db = new DataClasses1DataContext();
                    
                    var meterIds = lst.Select(n => n.meterId).Distinct().ToList();
                    var dates = lst.Select(n => n.mydate).Distinct().ToList();
    
                    var myfLst = new List<RemoteReadings>();
                    // To avoid the following SqlException, Linq query should be exceuted in batches as follows.
                    //{System.Data.SqlClient.SqlException 
                    // The incoming tabular data stream (TDS) remote procedure call (RPC) protocol stream is incorrect.
                    // Too many parameters were provided in this RPC request. The maximum is 2100.
                    foreach (var batch in dates.Batch(2000))
                    {
                        //  Gets a list of possible matches   from DB.
                        var probableMatches = (from ri in db.RemoteReadingss
                                               where (meterIds.Contains(ri.meterId)
                                               && batch.Contains(ri.mydate))
                                               select new { ri.meterId, ri.mydate }).ToList();
    
                        // Join the  probableMatches with the lst in memory on unique
                        // constraints meterid.date to find any duplicates
                        var duplicates = (from existingRi in probableMatches
                                          join newRi in lst
                                          on new
                                          {
                                              existingRi.meterId,
                                              existingRi.mydate
                                          }
                                          equals new { newRi.meterId, newRi.mydate }
                                          select newRi).ToList();
    
                        //Add duplicates in a new List due to batch executions.
                        foreach (var s in duplicates)
                        {
                            myfLst.Add(s);
                        }
                    }
    
                    // Remove the duplicates from lst found in myfLst;
                    var insertList = lst.Except(myfLst).ToList();
    
                    return insertList;
    
                }
                catch
            (Exception ex)
                {
                    return null;
                }
            }
    		
    
    // Found this extension Class to divide IEnumerable in batches.
    // http://stackoverflow.com/a/13731854/288865
     public static class MyExtensions
        {
            public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items,
                                                               int maxItems)
            {
                return items.Select((item, inx) => new { item, inx })
                            .GroupBy(x => x.inx / maxItems)
                            .Select(g => g.Select(x => x.item));
            }
        }
