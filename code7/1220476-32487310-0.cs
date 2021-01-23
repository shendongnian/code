    if (ModelState.IsValid)
    {
        // Success
        // Save or whatever
        return RedirectToAction("Foo");
    }
    
    // Error
    return View(model);
