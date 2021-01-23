    string exmsg="";
    try
    {
    //....
    }
    catch (Exception ex)
    {
     exmsg = ex.Message;                
    }
      return RedirectToAction("FileUpload", "FileUpload",exmsg);
    }
    [HttpGet]
        public ActionResult FileUpload(string errormsg)
        {
           ViewBag.Error=errormsg
           return View(p);
        }
