    pubilc ActionResult AssignProject()
    {
      var vm = new AssignProjectOwnerShipVm();
      vm.Projects = db.Projects.Select(s=>new SelectListItem
                          {
                            Value = s.ProjectId.ToString(),
                            Text = s.ProjectName 
                          }).ToList();
      vm.Partners=db.Users_projects
           .Where(p => p.project_id == project_id &&p.project_role == "partner")
           .Select(up =>
           new SelectListItem {
                         // You may append User email also here
                         Text= up.AspNetUsers.FirstName +" "+up.AspNetUsers.LastName,
                         Value = up.AspNetUsers.Id.ToString() })
       .ToList();
     return View(vm);
    }
