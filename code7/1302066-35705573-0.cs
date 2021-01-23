	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Edit(GameViewModel viewModel)
	{
		if (ModelState.IsValid)
		{
			List<Platform> selectedPlatforms = new List<Platform>();
			if (viewModel.PostedPlatforms != null)
			{
				int[] platformIds = Array.ConvertAll(viewModel.PostedPlatforms.PlatformIds, p => Convert.ToInt32(p));
				selectedPlatforms.AddRange(db.Platforms.Where(item => platformIds.Contains(item.PlatformId)).ToList());
			}
			
			var game = GetGameById(viewModel.Id);
			
			UpdateGamePlatforms(game, selectedPlatforms);
			
			db.Entry(game).CurrentValues.SetValues(viewModel.game);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		return View(viewModel.Review);
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
