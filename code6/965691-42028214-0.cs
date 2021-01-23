    var ms = new System.IO.MemoryStream();
    var sw = new System.IO.StreamWriter(ms);
    var csvOut = new CsvWriter(sw, new Configuration.CsvConfiguration() { Delimiter = ";", IgnoreReferences = true });
    csvOut.WriteRecords(someCollection);
    // IMPORTANT LINE
    sw.Flush();
    ms.Position = 0;
    return File(ms, "text/csv", "resultFile.csv");
