    public ActionResult Index()
    {
        XDocument xml = XDocument.Load(xmlPath);
        var shifts = (from b in xml.Descendants("Shift")
                      select new ShiftsModel
                     {
                         UID = (string)b.Attribute("UID"),
                         Date = (string)b.Element("Date"),
                         Time = (string)b.Element("Time"),
                         Location = (string)b.Element("Location")
                     }).ToList();
        ViewData.Model = shifts; // this line will pass your object but now to model
        return View();
    }
