    // method is async and returns a Task
    public async Task<IActionResult> Index()
    {
        var userId = User.GetUserId();
        // call `FindByIdAsync` and await the result
        ApplicationUser user = await userManager.FindByIdAsync(userId);
        ViewBag.UserId = userId;
        ViewBag.DefaultListId = user.DefaultListId;
        return View();
    }
