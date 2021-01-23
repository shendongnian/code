    using (var ps = new Promotionalsponsorship(constr))
    {
    	var applicationToSave = ps.Application.Find(application.ApplicationId);
    	if (applicationToSave == null)
    		applicationToSave = new Application();
    		
       	Mapper.Map(application, applicationToSave);  //May not be accurate, search for the  
                                              //method that writes into an existing object
    
        if (applicationToSave.ApplicationId == default(int))
        {
            ps.Application.InsertOnSubmit(applicationToSave);
        }                
    
        ps.Application.Context.SubmitChanges();
     } 
