    var Model = new ViewModel
    {
        Teachers = db.Teachers.ToList(),
    };
    return View(Model);
