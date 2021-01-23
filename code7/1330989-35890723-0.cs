    public ActionResult ChartererModal(string id)
    {
        int intValue;
        bool parsed = Int32.TryParse(id, out intValue);
        if (!parsed)
            throw new Exception("Error during parsing string to integer");
        var fixtures = db.tbl_vessel_fixtures.Find(intValue);
        var vm = Mapper.Map<FixtureViewModel>(fixtures);            
        return PartialView("_ChartererDetails", vm);
    }
