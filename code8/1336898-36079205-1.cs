       string exmsg="";
        try
        {
        //....
        }
        catch (Exception ex)
        {
         exmsg = ex.Message;                
        }
        return RedirectToAction("FileUpload", "Controllername", new { errormsg = exmsg });
        }
    [HttpGet]
        public ActionResult FileUpload(string errormsg)
        {
           ViewBag.Error=errormsg
           return View(p);
        }
