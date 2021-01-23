    viewModel.Colleges= db.Colleges
        .Include(i => i.Address1)
        .Include(i => i.Address2)
        .Include(i => i.Address3)
        .Include(i => i.County.CountyName)
        .Include(i => i.CollegeStatus)
        .Include(i => i.ContactMobilePhone)
        .Include(i => i.ContactName)
        .Include(i => i.Name)
        .Include(i => i.Courses.Select(c => c.CourseID))
        .OrderBy(i => i.Name);
