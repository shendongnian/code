    [HttpGet]
    public ActionResult Update(string username)
    {
         ManageUser user = new ManageUser();    
         user =GetData(username);//call data access            
         return View(user);
    }
