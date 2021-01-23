    class BatchCellUpdater
      {
        // The number of rows to fill in the destination workbook
        const int MAX_ROWS = 75;
    
        // The number of columns to fill in the destination workbook
        const int MAX_COLS = 5;
    
        /**
         * A basic struct to store cell row/column information and the associated RnCn
         * identifier.
         */
        private class CellAddress
        {
          public uint Row;
          public uint Col;
          public string IdString;
    
          /**
           * Constructs a CellAddress representing the specified {@code row} and
           * {@code col}. The IdString will be set in 'RnCn' notation.
           */
          public CellAddress(uint row, uint col)
          {
            this.Row = row;
            this.Col = col;
            this.IdString = string.Format("R{0}C{1}", row, col);
          }
        }
    
        static void Main(string[] args)
        {
          string key;
    
          // Command line parsing
          if (args.Length != 1)
          {
            Console.Error.WriteLine("Syntax: BatchCellUpdater <key>");
            return;
          }
          else
          {
            key = args[0];
          }
    
          // Prepare Spreadsheet Service
          SpreadsheetsService service = new SpreadsheetsService("MySpreadsheetIntegration-v1");
    
          // TODO: Authorize the service object for a specific user (see other sections)
    
          CellQuery cellQuery = new CellQuery(key, "od6", "private", "full");
          CellFeed cellFeed = service.Query(cellQuery);
    
          // Build list of cell addresses to be filled in
          List<CellAddress> cellAddrs = new List<CellAddress>();
          for (uint row = 1; row <= MAX_ROWS; ++row)
          {
            for (uint col = 1; col <= MAX_COLS; ++col)
            {
              cellAddrs.Add(new CellAddress(row, col));
            }
          }
    
          // Prepare the update
          // GetCellEntryMap is what makes the update fast.
          Dictionary<String, CellEntry> cellEntries = GetCellEntryMap(service, cellFeed, cellAddrs);
    
          CellFeed batchRequest = new CellFeed(cellQuery.Uri, service);
          foreach (CellAddress cellAddr in cellAddrs)
          {
            CellEntry batchEntry = cellEntries[cellAddr.IdString];
            batchEntry.InputValue = cellAddr.IdString;
            batchEntry.BatchData = new GDataBatchEntryData(cellAddr.IdString, GDataBatchOperationType.update);
            batchRequest.Entries.Add(batchEntry);
          }
    
          // Submit the update
          CellFeed batchResponse = (CellFeed)service.Batch(batchRequest, new Uri(cellFeed.Batch));
    
          // Check the results
          bool isSuccess = true;
          foreach (CellEntry entry in batchResponse.Entries)
          {
            string batchId = entry.BatchData.Id;
            if (entry.BatchData.Status.Code != 200)
            {
              isSuccess = false;
              GDataBatchStatus status = entry.BatchData.Status;
              Console.WriteLine("{0} failed ({1})", batchId, status.Reason);
            }
          }
    
          Console.WriteLine(isSuccess ? "Batch operations successful." : "Batch operations failed");
        }
    
        /**
         * Connects to the specified {@link SpreadsheetsService} and uses a batch
         * request to retrieve a {@link CellEntry} for each cell enumerated in {@code
         * cellAddrs}. Each cell entry is placed into a map keyed by its RnCn
         * identifier.
         *
         * @param service the spreadsheet service to use.
         * @param cellFeed the cell feed to use.
         * @param cellAddrs list of cell addresses to be retrieved.
         * @return a dictionary consisting of one {@link CellEntry} for each address in {@code
         *         cellAddrs}
         */
        private static Dictionary<String, CellEntry> GetCellEntryMap(
            SpreadsheetsService service, CellFeed cellFeed, List<CellAddress> cellAddrs)
        {
          CellFeed batchRequest = new CellFeed(new Uri(cellFeed.Self), service);
          foreach (CellAddress cellId in cellAddrs)
          {
            CellEntry batchEntry = new CellEntry(cellId.Row, cellId.Col, cellId.IdString);
            batchEntry.Id = new AtomId(string.Format("{0}/{1}", cellFeed.Self, cellId.IdString));
            batchEntry.BatchData = new GDataBatchEntryData(cellId.IdString, GDataBatchOperationType.query);
            batchRequest.Entries.Add(batchEntry);
          }
    
          CellFeed queryBatchResponse = (CellFeed)service.Batch(batchRequest, new Uri(cellFeed.Batch));
    
          Dictionary<String, CellEntry> cellEntryMap = new Dictionary<String, CellEntry>();
          foreach (CellEntry entry in queryBatchResponse.Entries)
          {
            cellEntryMap.Add(entry.BatchData.Id, entry);
            Console.WriteLine("batch {0} (CellEntry: id={1} editLink={2} inputValue={3})",
                entry.BatchData.Id, entry.Id, entry.EditUri,
                entry.InputValue);
          }
    
          return cellEntryMap;
        }
      }
