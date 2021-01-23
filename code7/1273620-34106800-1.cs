    ViewBag.Id =db.Users_projects
       .Where(p => p.project_id == project_id &&p.project_role == "partner")
       .Select(up =>
       new SelectListItem {
                         // You may append User email also here
                         Text= up.AspNetUsers.FirstName +" "+up.AspNetUsers.LastName,
                         Value = up.AspNetUsers.Id.ToString() })
       .ToList();
