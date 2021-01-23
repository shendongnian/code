    public IEnumerable<MemberObj> GetMem(String code)
    {
    	int soureID = db.Sources.Where(s => s.sourceRef == code); //I'm assuming code is the source ref??
    
    	return db.Members.Where(m => m.sourceId == sourceID);
    }
