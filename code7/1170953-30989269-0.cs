    var viewModel = from p in db.Providers
                    orderby p.Name
                    select new ProviderViewModel
                    {
                      Prop1 = p.Prop1,
                      Prop2 = p.Prop2 + " " + p.prop3
                      etc...
                    };
    
    int pageSize = 9;
    int pageNumber = (page ?? 1);
    
    return View(viewModel.ToPagedList(pageNumber, pageSize));
        
 
