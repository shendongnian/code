    public ActionResult Index(string searchString)
        { 
            var lowerSearchString = searchString.ToLower();
            var db = new ArponClientPosContext();
            var students = from s in db.Pos
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                db = db.Pos.Where(s => s.Descripcion.ToLower().Contains(lowerSearchString));
            }
            return View("~/Views/HomePos/Index.cshtml", db.Pos.ToList());
           
        }
