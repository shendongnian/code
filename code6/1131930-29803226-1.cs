    var x = Request["groupCode"];
    var affectedGroup = db.StudentGroups.FirstOrDefault(s => s.Code == x);
    var groupId = affectedGroup.Id;
    if (affectedGroup != null && !affectedGroup.Any())
       {
          affectedGroup.StudentIds = new List<string>();
          affectedGroup.StudentIds.Add(loggedInUserId);   
       }
    else if (affectedGroup.StudentIds.Contains(loggedInUserId))
       {
          TempData["ErrorMessage"] = "You are already a member of this group";
       }
        
    db.SaveChanges();
