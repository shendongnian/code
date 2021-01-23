    string sBuff;
    using (StringWriter sw = new StringWriter())
    using (CsvWriter csv = new CsvWriter(sw))
    {
        csv.WriteRecord<SomeItem>(r);
        sBuff = sw.ToString();
    }
    Console.WriteLine(sBuff);
