    using (StreamReader sr = new StreamReader(@"C:\Temp\empIN.csv"))
    using (StreamWriter sw = new StreamWriter(@"C:\Temp\empOUT.csv"))
    using (CsvWriter cw = new CsvWriter(sw))
    using (CsvReader cr = new CsvReader(sr))
    {
        cw.WriteHeader<Employee>();
        var records = cr.GetRecords<Employee>();
    
        foreach (Employee emp in records)
        {
            emp.Wage *= 1.1F;
            cw.WriteRecord<Employee>(emp);
        }
    }
