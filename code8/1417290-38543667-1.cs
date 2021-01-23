    public ActionResult PageOfGlory(){
        string value = Request.Form["dllSalutation"];
        string[] validSalutations = new string[]{
            "Mr",
            "Ms"
        };
        if(!validSalutations.Contains(value)){
            ModelState.AddModelError("","Invalid Salutation");
            return View();
        }
        //Add stuff to database
    }
