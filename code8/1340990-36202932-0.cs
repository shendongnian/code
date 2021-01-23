     public ActionResult Index()
        {            
            ViewData["MyCategory"] =  GetMyCategoryList();
            return View();
        }
     public List<SelectListItem> GetMyCategoryList()
        {
            List<SelectListItem> lstMyCategory = new List<SelectListItem>();
            var data = new[]{
                 new SelectListItem{ Id=1,MyCategoryText="Federal"},
                 new SelectListItem{ Id=2,MyCategoryText="General"},
                 new SelectListItem{ Id=3,MyCategoryText="Cash"},                 
             };
            lstMyCategory = data.ToList();
            return lstMyCategory;
        }
