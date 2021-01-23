    Menu mn = menus.OrderBy(x => x.Order).FirstOrDefault(m => m.Value == null);
    if(mn != null)
    {
        // Got it
    }
    else
    {
        // No match for your condition
    }
  
