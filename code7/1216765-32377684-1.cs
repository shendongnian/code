    public async Task<ActionResult> GetBenches([DataSourceRequest] DataSourceRequest request)
    {
        BenchesService bService = new BenchesService();
        List<Bench> obj = await bService.getBenches();
        Console.WriteLine("ALAL");
    
        return Json(obj.Select(s => new Bench
            {
                id = s.id,
                bookable = s.bookable,
                name = s.name,
                seatsCount = s.seatsCount,
                zone = s.zone
    
            }).Distinct().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
    }
