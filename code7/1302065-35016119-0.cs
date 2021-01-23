    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(GameViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            List<Platform> selectedPlatforms = viewModel.Select(pl => GetPlatformById(pl.Id)).ToList();
            var game = GetGameById(viewModel.Id);
        
            UpdateGamePlatforms(game, selectedPlatforms);
       
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(viewModel.Game);
        }        
        
        
        
    private Platform GetPlatformById(int platformId)
    {
        return db.Platforms.First(pl => pl.Id == platformId);
    }
 
    private Game GetGameById(int gameId)
    {
        return db.Games.First(g => g.Id == gameId);
    }
 
    private void UpdateGamePlatforms(Game game, IList<Platform> selectedPlatforms)
    {
        var gamePlatforms = game.Platforms.ToList();
        foreach (var gamePlatform in gamePlatforms)
        {
            if (selectedPlatforms.Contains(gamePlatform) == false)
            {
                game.Platforms.Remove(gamePlatform);
            }
            else
            {
                selectedPlatforms.Remove(gamePlatform);
            }
        }
        game.Platforms.AddRange(selectedPlatforms);
    }
