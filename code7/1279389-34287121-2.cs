    var parser = new TSql100Parser(true); 
    var script = parser.Parse(reader, out errors) as TSqlScript;
 
    foreach (TSqlBatch batch in script.Batches)
    {
       foreach (TSqlStatement statement in batch.Statements)
       {
           //At this point, you have a collection of SQL Statements... 
           //that can contain collections of SQL Statements...  
       }
    }
