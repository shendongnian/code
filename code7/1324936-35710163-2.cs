        public ActionResult SaveSelection(Mytable obj)
        {
            try 
            {
              ....logic here....
              return Json("Your selections have been saved.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //TODO: log exception
                return new HttpStatusCodeResult(401, ex.Message);
            }
        }
