    public ActionResult Foo()
    {
        LookUpViewModel ViewModel = new LookUpViewModel();
        using(RosterManagementEntities rosterManagementContext = new RosterManagementEntities())
        {
            ViewModel.tblCurrentLocations = from o in rosterManagementContext.tblCurrentLocations select o;
            ViewModel.tblStreams = from o in rosterManagementContext.tblStreams select o; 
        }
        return View(ViewModel);
    }
