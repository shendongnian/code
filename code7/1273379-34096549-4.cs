    public ActionResult Edit(int id)
    {
        var vm = new CreateOrderViewModel();
        var order = dbContext.Orders.FirstOrDefault(s=>s.Id==id);
        vm.TechList = GetItems();
        //This is where you set the selected value which you read from db
        vm.SelectedTech = order.SelectedTechId;
        
        return View(vm);
    }
    
    private List<SelectListItem> GetItems()
    {
        // just for demo. You may change the LINQ query to get your data. 
        // Just make sure to return a List<SelectListItem>
        return db.Users.Select(s => new SelectListItem   
        { 
            Value = s.Id.ToString(),
            Text = s.Name
        }).ToList();
    }
