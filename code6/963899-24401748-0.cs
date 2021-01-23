    public IQueryable<CollegeDataLibrary.CollegeDetail> GetData()
    {
        var context = DataOperations.GetCollegeDetails();
        return context.AsQueryable();
    }
