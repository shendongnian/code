    var est =
        MyDB.DetailTableSet.Where(e => e.SRC_System == Location && e.Segment_ID == Segment_ID 
            && e.Transaction_Date >= Start_Date && e.Transaction_Date <= End_Date)
            .GroupBy(e => 1)
            .Select(e => new Header_ViewModel
            {
                Amount1 = e.Sum(x => x.Amount1),
                Amount2 = e.Sum(x => x.Amount2),
            })
            .SingleOrDefault() ?? new Header_ViewModel();
            
    var entity = new HeaderTable()
    {
        Transaction_ID = obj.Transaction_ID,
        Value1 = obj.Value1,
        Value2 = obj.Value2,
        Value3 = obj.Value3,
        // Summary from detail table
        Amount1 = est.Amount1,
        Amount2 = est.Amount2,
        Location = Location,
        Segment_ID = Segment_ID,
        Start_Date = Start_Date,
        End_Date = End_Date,
        // assign default values
        Updated_By = "Myself",
        Updated_Date = DateTime.Now
    };
    // Add the entity
    MyDB.HeaderTableSet.Add(entity);
    // Store the entity for later use
    entities.Add(entity);
