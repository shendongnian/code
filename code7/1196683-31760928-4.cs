	public ActionResult Post(string recipyName, string[] ingredients)
	{
		var recipy = new Recipy
		{
			Name = recipyName,
			Ingredients = ingredients.Select(x => new Ingredient
			{
				Name = x,
				Unit = "pcs.",
				Amount = 1,
			}).ToList(),
		}
		
		using (var context = new RecipyContext())
		{
			context.Recipes.Add(recipy);
			context.SaveChanges();
		}
		
		return Ok();
	}
