        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult actionName(Model pModel){
        
        HttpPostedFileBase File = Request.Files["File1"];
        if (File != null && File.ContentLength != 0){
                     //do what you want
        }
        
        }
