        mydbEntities ef = new mydbEntities (); //mydbEntities is derived from DbContext
        ef.Database.Log = s => System.Diagnostics.Debug.WriteLine (s);
        Invoice inv = ef.Defects
            .Include(d => d.Invoice)
            .Where (i => i.Id == 5)
            .SingleOrDefault()
            .Invoice;
