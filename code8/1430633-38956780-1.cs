    List<SampleItem> sList = new List<SampleItem>();
    
    using (StreamReader sr = new StreamReader(@"C:\Temp\sample.csv", false))
    using (CsvReader csv = new CsvReader(sr))
    {
        csv.Configuration.Delimiter = ",";
        csv.Configuration.HasHeaderRecord = true;
        csv.Configuration.RegisterClassMap<SampleItem.SampleItemMap>();
    
        sList = csv.GetRecords<SampleItem>().ToList();
        dgv2.DataSource = sList;
    }
