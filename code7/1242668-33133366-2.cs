    public ActionResult Home()
    {
       var ny = Product.GetAllTeamMembers();
    
       return view(ny);
    }
