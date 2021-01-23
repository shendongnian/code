    if (!ModelState.IsValid)
    {
         ConfigureViewModel(model); // only necessary if you need to return the view
         return View(model);
    }
    // save and redirect
