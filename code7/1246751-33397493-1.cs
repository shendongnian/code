    using (DatabaseEntities context = new DatabaseEntities())
    {
        if (ofacFile != null)
        {
            var csv = new CsvReader(ofacFile);
            csv.Configuration.TrimFields = true;
            csv.Configuration.HasHeaderRecord = false;
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE ofac_sdn");
                            
            while (csv.Read())
            {
                if (csv.GetField<string>(0) == "\u001a")
                {
                    break; // End of file
                }
    
                var ofac = new ofac_sdn
                {
                    ent_num = csv.GetField<int>(0),
                    SDN_Name = csv.GetField<string>(1),
                    SDN_Type = csv.GetField<string>(2),
                    Program = csv.GetField<string>(3),
                    Title = csv.GetField<string>(4),
                    Call_Sign = csv.GetField<string>(5),
                    Vess_type = csv.GetField<string>(6),
                    Tonnage = csv.GetField<string>(7),
                    GRT = csv.GetField<string>(8),
                    Vess_flag = csv.GetField<string>(9),
                    Vess_owner = csv.GetField<string>(10),
                    Remarks = csv.GetField<string>(11)
                };
    
                context.ofac_sdn.Add(ofac);
            }
        }
    }
