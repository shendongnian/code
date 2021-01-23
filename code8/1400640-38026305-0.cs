    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Register(TalentInfo model, IEnumerable<HttpPostedFileBase> files)
    {
        if (ModelState.IsValid)
        {
            //you have lots of code here....
        }
        else
        {
            //you need to return something here....because (ModelState.IsValid) might be false
        }
    }
