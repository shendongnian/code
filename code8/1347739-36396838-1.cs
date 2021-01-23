        public ActionResult displaycustomer()
        {
            List<View_VisitorsForm> objvisitlist = (from v in db.View_VisitorsForm select v).ToList();
            VisitorsViewModel model = new VisitorsViewModel();
            model.Visits = objvisitlist; 
            return View(model);
        }
