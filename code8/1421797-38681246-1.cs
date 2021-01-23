    public ActionResult CityJson(string id)
        {
            var state = db.States.FirstOrDefault(x => x.Name == id);
            var model = db.Cities.Where(x => x.StateId == state.Id).Select(x => new { x.Name }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
