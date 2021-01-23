    using (TextReader prodFile = System.IO.File.OpenText(filePath))
    {
        CsvReader csv = new CsvReader(prodFile);
        csv.Configuration.IgnoreHeaderWhiteSpace = true;
        List<PulProduct> prodList = csv.GetRecords<PulProduct>().ToList();
    }
