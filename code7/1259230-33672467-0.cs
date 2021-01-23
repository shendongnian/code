    var s = db.UserTasks.Where(o=>o.Id=="10027").First();
    		    
    s.Id = 10027;
    s.Description ="test change";
    s.Title = "Test change";
    s.DueDate = DateTime.Now.AddHours(3);
    s.CreatedBy = db.Users.Where(c=>c.UserName=="Bob").First();
    s.AssignedTo = db.Users.Where(c => c.UserName == "Stephen").First();
