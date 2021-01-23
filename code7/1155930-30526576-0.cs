     public ActionResult SelectRes(int id)
        {
            var ResList = resrepository.GetAll();
    
            ViewData["ResList"] = ResList;
    
            return View(svcresrelationRepository.GetAll());
        }
