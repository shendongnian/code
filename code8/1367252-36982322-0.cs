    public async Task<ActionResult> BlaBla()
    {
        if (!ModelState.IsValid)
        {
            return new HttpNotFoundResult();
        }
    
        MyViewModel model = await myService.GetTheModel();
        return View(model);
    }
