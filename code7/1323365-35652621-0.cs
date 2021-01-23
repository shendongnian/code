    var textToParse = @"SupplierSku,CatIds,StockStatus,Active
    %ADA-BB-124%|4,5,1|%AV%|1
    %XAS-E4-S11%|97,41,65|%OS%|0";
    string supplierSku;
    string stockStatus;
    using (var stringReader = new StringReader(textToParse))
    {
        using (var reader = new CsvReader(stringReader))
        {
            reader.Configuration.Delimiter = ",";
            reader.Configuration.HasHeaderRecord = true; // If there is no header, set to false.
            while (reader.Read())
            {
                supplierSku = reader.GetField("SupplierSku"); // Or reader.GetField(0)
                stockStatus = reader.GetField("StockStatus"); // Or reader.GetField(2)
                Console.WriteLine($"SKU: {supplierSku}; Status: {stockStatus}");
            }
        }
    }
