    using (MainDataContext context = new MainDataContext())
    {
        var uniqueIds = personIds.Distinct().ToList();
        if(uniqueIds.Count > 4)
            return Enumerable.Empty<Mission>().AsQueryable();
        var result = context.Missions;
        foreach(int id in uniqueIds)
        {
            result = result.Where(t => id == t.DoctorID || 
                                       id == t.NurseID || 
                                       id == t.OperatorID ||
                                       id == t.DriverID);
        }
        return result;
    }
