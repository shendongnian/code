    public ActionResult Index(string searchString = "")
        { 
            var db = new ArponClientPosContext();            
            var lowerSearch = searchString.ToLower();
            var students = from s in db.Pos
                       where s.Descripcion.ToLower().Contains(lowerSearch)
                       select s;
            return View("~/Views/HomePos/Index.cshtml", students.ToList());
           
        }
    
