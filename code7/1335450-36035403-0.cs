    private void AggiornaVersioneCappario()
    {
        try
        {
            if (modelCap.AZCPR00F.Count() > 0)
            {
                modelCap.Database.ExecuteSqlCommand("TRUNCATE TABLE [AZCPR00F]");
                modelCap.Database.ExecuteSqlCommand("DBCC CHECKIDENT('AZCPR00F', RESEED, 0);");
                modelCap.AZCPR00F.Local.Clear();
            }
            StreamReader reader = new StreamReader(str_azcpr00f);
            string contents;
            while ((contents = reader.ReadLine()) != null)
            {
                AZCPR00F verCap = new AZCPR00F();
                verCap.CPRVER = contents.Substring(1, 5);
                verCap.CPRDDE = contents.Substring(7, 8);
                verCap.CPRDSC = contents.Substring(16, 8);
                modelCap.AZCPR00F.Add(verCap);
            }
            modelCap.SaveChanges();
                reader.Close();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
