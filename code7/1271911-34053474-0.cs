    public ActionResult SomeMethod(int status) //Assume 4 is passed in
    {
        if (status == 1)
        {
            return PartialView("partial1", model);
        }
        if (status == 2)
        {
           return PartialView("partial2", model);
        }
        if (status == 3)
        {
            return PartialView("partial3", model);
        }
    
        //We got here, but haven't returned anything!
    }
