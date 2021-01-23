    [HttpPost]
    public ActionResult Create(CoursesViewModel viewModel)
    {
        if( !this.IsCoursesViewModelValid( this.db, viewModel ) ) {
            this.ModelState.AddError("some error message");
            return this.View();
        }
        
        DBCourse dbCourse = new DBCourse();
        dbCourse.Name = viewModel.CourseName;
        db.Courses.Add( dbCourse );
        db.SaveChanges();
        return this.View();
    }
    private Boolean IsCoursesViewModelValid(DataContext db, CoursesViewModel viewModel) {
        return db.Courses.Where( dbC => dbC.CourseName == viewModel.CourseName ).Count() == 0;
    }
