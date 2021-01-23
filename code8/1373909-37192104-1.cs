    public ActionResult Index()
        {
        AllDBModels allModels = new AllDBModels();
        allModels.AllGraphs = new Graph();
        allModels.AllGraphs.Charts = new List<Highcharts>();
        ChartsModel model = new ChartsModel();
        model.Charts = new List<Highcharts>();
        ViewBag.Rooms = db.namtar_studyrooms.ToList() //the collection here (you should changeit, just an example)
    }
