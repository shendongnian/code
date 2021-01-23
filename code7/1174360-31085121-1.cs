    var clientViewModel = db.Clients.Where(x => x.Id == id)
        .Select(x => new ClientViewModel
        {
            // Map Client domain model to Client view model
        })
        .FirstOrDefault();
    
    var projectViewModels = from p in db.Projects
        where p.ClientId == id
        select new ProjectViewModel
        {
            // Map Project domain model to Project view model
        };
    
    var editViewModel = new EditViewModel
        {
            Client = clientViewModel,
            Projects = projectViewModels
        };
    
    return View(editViewModel);
