    public void SavePrescriber(string id)
    {
        var data = context.FullMasters.Where(x => x.NPI == id).FirstOrDefault();
        Prescriber p = new Prescriber
        {
            First = data.FirstName,
            Last = data.LastName,
            DEA = data.DEA,
            License = data.LIC,
            Life = data.Life_Hosp,
            NPI = data.NPI
        };
        context.EPCS_Prescribers.Add(p);
        context.SaveChanges();
    }
