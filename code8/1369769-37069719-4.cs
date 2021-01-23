    var changedCollection =  _context.SelectedEmployees.Select(x => 
        {
           x.Phones.Select(y => 
                          { 
                             y.IsPhoneAssigned = true;
                             return y;
                          })
        }).ToList();
        
    _context.SubmitChanges();
