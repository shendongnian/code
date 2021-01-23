    public IHttpActionResult Put(LegalEntity legalEnt)
    {        
        List<DBAName> dba = new List<DBAName>();
        dba = db.DBAName.Where(d => d.LegalEntityID == legalEnt.LegalEntityID).ToList();
        var addArray = legalEnt.DBANames.Select(x => x.LegalEntityID).Except(dba.Select(y => y.LegalEntityID)).ToList();
        var delArray = dba.Select(x => x.LegalEntityID).Except(legalEnt.DBANames.Select(y => y.LegalEntityID)).ToList();
    }
