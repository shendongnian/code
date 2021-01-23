    private IEnumerable<RwsBasePhonesAndAddress> PopulateQuery(string SelectedCampus, 
        string SelectedRelationship)
    {
        IEnumerable<RwsBasePhonesAndAddress> query =
            db.RwsBasePhonesAndAddresses.Where(m => m.Campus == SelectedCampus);
        
        if(string.IsNullOrEmpty(SelectedRelationship))
            query = query.Where(m => m.Relationship == null);
        else if (SelectedRelationship != "All")
            query = query.Where(m => m.Relationship == SelectedRelationship);
    
        query = query.OrderBy(m => m.StudentName).AsEnumerable();
        return query;
    }
