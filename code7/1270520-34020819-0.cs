    public ActionResult Employee()
    {
        List<ResourceModel> resources = new List<ResourceModel>();
    
        resources.Add(new ResourceModel() { Id = 1, FirstName = "Piet", LastName = "Willemse" });
        resources.Add(new ResourceModel() { Id = 2, FirstName = "Jan", LastName = "Janssen" });
        resources.Add(new ResourceModel() { Id = 3, FirstName = "Willem", LastName = "Willemse" });
        resources.Add(new ResourceModel() { Id = 4, FirstName = "Hendrik", LastName = "Willemse" });
        resources.Add(new ResourceModel() { Id = 5, FirstName = "James", LastName = "Janssen" });
    
        var orderedResources = resources.OrderBy(r => r.LastName).Select(m => new ResourceModel()
        {
            Id = m.Id,
            LastName = m.LastName,
            FirstName = m.FirstName
        }).ToList();
    
        return View(orderedResources);
    }
