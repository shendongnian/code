    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public ActionResult Register(int id)
    {
        if (id == 0)
            return View("Index");
    
        var now = DateTime.Now;
    
        var userId = User.Identity.GetUserId();
    
        var registration = this.repo.GetRegistration(id, userId);
    
        if (registration != null)
        {
            ViewBag.Registered = true;
        }
        else
        {
            var successful = this.repo.RegisterEvent(id, userId);
    
            if (successful)
            {
                return View();
            }
            else
            {
                return View();
            }
        }
        return View();
    }
