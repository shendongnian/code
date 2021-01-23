    public JsonResult GetCity(string name)
        {
            var cities = from c in context.Cities
                            orderby c.Name
                            select c;
            var chosenCities = cities.Where(c => c.Country.Name == name).Select(c => new{ Value = c.CityID, Text = c.Name });
            return Json(chosenCities, JsonRequestBehaviour.AllowGet);
        }
