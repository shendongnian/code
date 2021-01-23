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
