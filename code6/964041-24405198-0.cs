    [ActionName("Index")]
        [HttpPost]
        public ActionResult IndexPost(FormCollection form, QcMatchViewModel model)
        {
          if(form["btnAcceptAll"]!=null)
           {
            //Accept Button Code
           }
           if(form["btnRejectAll"]!=null)
           {
            //Reject Button Code
           }
            //Save Record and Redirect
            return RedirectToAction("Index");
        }
