         public SelectList GetCountrySelectList() 
         {
           var countries = Country.GetCountries();
           return new SelectList(countries.ToArray(),
                        "Code",
                        "Name");
         }
      public ActionResult IndexDDL() 
      {
       ViewBag.Country = GetCountrySelectList();
       return View();
      }
