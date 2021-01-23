    var viewModel = db.Clubs
        .Where(t => t.ClubID == clubID)
        .Select(t => new ClubDetailsViewModel
        { .. })
        .FirstOrDefault();
    return View(viewModel);
