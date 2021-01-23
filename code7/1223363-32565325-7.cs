        public ActionResult CountryDetails(int id)
        {
            var model = new CountryDTO();
            using (var dbContext = new DATABASE_CONTEXT())
            {
                var country = dbContext.Country.First(s => s.CountryId == id);
                model.CountryName = country.CountryName;
                // Same for other Properties
                // You can use AutoMapper Library to Map from Model to DTO/ViewModel
            }
            return View(model);
        }
