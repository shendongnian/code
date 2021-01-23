    public ActionResult Data(int pageName)
    {
        if (pageName == 1000)
        {
            // Notice the return statement in front of the RedirectToAction call
            return this.RedirectToAction("Data", new { pageName = 500 });
        }
    
        ... something else
    }
