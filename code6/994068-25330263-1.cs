		[HttpGet]
		public ActionResult Index()
		{
    		var model = new MyViewModel();			
			
			model.AvailableValues = PopulatedDropDown;
			model.SelectedAnimalId = "1";
    
			return View(model);
		}
		[HttpPost]
		public ActionResult Index(MyViewModel model)
		{
	        // Save it to db and rebind the selected
			model.AvailableValues = PopulatedDropDown;	
			 
		
			return View(model);
		}
        // helper property to populate from the enum
        private IEnumerable<SelectListItem> PopulatedDropDown
    	{			
    			get {
    				var enumList =	Enum.GetValues(typeof (AnimalEnum))
                .Cast<int>()
                .Select(i => 
    					new SelectListItem {
                        Text = Enum.GetName(typeof (AnimalEnum), i), 
                        Value = i.ToString()
    					
                    });
    				return enumList;
    			}
    	}
