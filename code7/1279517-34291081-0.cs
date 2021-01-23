    public JsonResult GetCity(string name)
        {
            var cities = from c in context.Cities
                            orderby c.Name
                            select c;
            var chosenCities = cities.Where(c=>c.Country.Name== name);
            return Json(new SelectList(chosenCities, "CityID", "Name"), JsonRequestBehaviour.AllowGet);
        }
