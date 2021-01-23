    var dbContext = new YourDbContext();//You will have to implement this class (see a get started for EF)
    var allProjects = dbContext.Projects;
    var specificProject = dbContext.Projects.Where(p => p.ProductId == 5);
    //Related Reviews will be availlable here
    var specificReviews = specificProject.Reviews;
