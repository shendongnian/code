	var line = Console.ReadLine();
	while (line.ToLower().Trim() != "exit")
	{
		var ingridients = line.Split(',');
		Console.WriteLine("\nAre you looking for following receipes:");
		var recipes = _uow.IngridientInRecipe.All;
		foreach (var ingridient in ingridients)
		{
			recipes = recipes.Intersect(_uow.IngridientInRecipe.All.Where(a => a.Ingridient.IngridientName.Contains(ingridient)));
		}
		foreach (var recipe in recipes.ToList())
		{
			Console.WriteLine(recipe.Recipes.RecipeName);
		}
		Console.WriteLine();
		line = Console.ReadLine();
	}
