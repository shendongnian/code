        [HttpPost]
        public ActionResult CreateCountry(CountryDTO model)
        {
            if (ModelState.IsValid)
            {
                // Model State is Valid
                // here you will create Context
                using (var dbContext = new DATBASE_CONTEXT())
                {
                    var newCountry = new Country() // Country is a Model from Database
                    {
                        CountryName = model.CountryName,
                        CentralLat = model.CentralLat,
                        // Map All Properties from View Model to Model
                    };
                    // Add the New Country to the Countries 
                    dbContext.Countries.Add(newCountry);
                    // Save Database Changes
                    dbContext.SaveChanges();
                }
            }
            return PartialView(model);
        }
