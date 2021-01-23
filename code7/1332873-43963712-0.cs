    This example when user closes a session
       public async Task<ActionResult> Logout()
            {
              return RedirectToAction("Index", "App");
            }
    
    where APP is the controller and Index is the action where I have within the App controller
    Appcontroller:
    
     in App controller I have this   
    
    public IActionResult Index()
            {
                return View();
            }
