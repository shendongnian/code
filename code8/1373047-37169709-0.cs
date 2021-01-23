    // GET: StudentRosterViewModels
    public ActionResult Index(string campus = "MRA", string fy="FY16")
    {
        IEnumerable<StudentRoster> query = db.StudentRosters.Where(m=>m.Campus==campus).ToList();
    
        // This successfully maps the domain model to the viewmodel
        // This IEnumerable will display in the "Table"
        IEnumerable<StudentRosterViewModel> mappedQuery =
            AutoMapper.Mapper.Map<IEnumerable<StudentRoster>, IEnumerable<StudentRosterViewModel>>(query);
    
        // The two remaining IEnumerables need to be mapped to 'mappedQuery'
        //   CampusListSelect and FiscalYearSelect
        // These two IEnumerables will populate the dropdownlists in Html.BeginForm()
        IEnumerable<SelectListItem> CampusList = new SelectList(new List<string> { "CRA", "DRA", "MRA", "PRA" }, campus);
        IEnumerable<SelectListItem> FiscalYearList = new SelectList(new List<string> { "FY12", "FY13", "FY14", "FY15", "FY16" }, fy);                
    
        var objForDynamicMapping = new 
        { 
            CampusListSelect = CampusList,
            FiscalYearListSelect = FiscalYearList
        };
     
        foreach(var mappedItem in mappedQuery)
        {
            // will create the mapping configuration dynamically
            AutoMapper.Mapper.DynamicMap(objForDynamicMapping, mappedItem);
        }
    
        return View(mappedQuery.ToList());
    }
