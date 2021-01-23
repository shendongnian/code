    public IHttpActionResult Put(LegalEntity legalEnt)
    {        
        List<DBAName> dba = new List<DBAName>();
        dba = db.DBAName.Where(d => d.LegalEntityID == legalEnt.LegalEntityID).ToList();
        var addArray = legalEnt.DBANames.Where(x => !dba.Select(y => y.LegalEntityID).Contains(x.LegalEntityID)).ToArray();
        var delArray = dba.Where(x => !legalEnt.DBANames.Select(y => y.LegalEntityID).Contains(x.LegalEntityID)).ToArray();
    }
