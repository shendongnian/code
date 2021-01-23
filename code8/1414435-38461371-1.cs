    // Get an entity with all the required PK values
    // In your example this will be the posted Department_Roles object
    var departmentRole = new Department_Roles() { Id = 1 };
    
    // Get the existing entry from the database
    var existingDepartmentRole = dbContext.Department_Roles.Find(departmentRole.Id);
    
    if (existingDepartmentRole == null)
    {
        throw new Exception("The existing department role could not be found using the PK values provided");
    }
    else
    {
        // Update the entry that we got out of the database and update the values
        existingDepartmentRole.username = "bob";
        existingDepartmentRole.role = "ProjectManager";
        existingDepartmentRole.service = "Management";
        existingDepartmentRole.short_plan = "permanant";
    
        // Save the changes
        dbContext.SaveChanges();
    }
