    public ActionResult GetMyView(bool? partial)
            {
               var model  = something;
               if (partial != null && partial)
                 { 
                    return PartialView("MyViewPartial", model)
                 }
                
                return View("MyViewPartial", model);
            }
