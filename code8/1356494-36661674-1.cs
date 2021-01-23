    string[] sizes = availableSizes.Split(','); // where availableSizes is your string
    MyViewModel model = new MyViewModel()
    {
        AvailableSizes = new SelectList(sizes),
        ReturnUrl = ....
    };
    return View(model);
