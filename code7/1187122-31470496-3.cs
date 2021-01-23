    var dbContext = new YourDbContext();
    var allProjects = dbContext.Projects;
    var specificProject = dbContext.Projects.Where(p => p.ProductId == 5);
    //Related Reviews will be availlable here
    var specificReviews = specificProject.Reviews;
