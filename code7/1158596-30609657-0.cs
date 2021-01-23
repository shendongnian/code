    //update all tasks with status of 1 to status of 2
    context.Tasks.Update(
        t => t.StatusId == 1, 
        t2 => new Task {StatusId = 2});
    //example of using an IQueryable as the filter for the update
    var users = context.Users.Where(u => u.FirstName == "firstname");
    context.Users.Update(users, u => new User {FirstName = "newfirstname"});
