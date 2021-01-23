    private Recipe ToRecipe(Document doc){
		Recipe recipe = new Recipe(doc.Id);
		recipe.UserId = doc.GetProperty<string> ("UserId");
		recipe.Title = doc.GetProperty<string> ("Title");
		recipe.IngredientsList = doc.GetProperty<List<string>> ("IngredientsList");
		recipe.Notes = doc.GetProperty<List<string>> ("Notes");
		recipe.Tags = doc.GetProperty<ISet<string>> ("Tags");
		recipe.Yield = doc.GetProperty<int> ("Yield");
		recipe.IngredientsWithHeaders = JsonConvert.DeserializeObject<List<Group<string, IngredientJson>>>(doc.GetProperty ("IngredientsWithHeaders").ToString());
		recipe.InstructionsWithHeaders = JsonConvert.DeserializeObject<List<Group<string, string>>>(doc.GetProperty("InstructionsWithHeaders").ToString());
		var rev = doc.CurrentRevision;
		var image = rev.GetAttachment ("image.jpg");
		if (image != null) {
			Debug.WriteLine ("There is an image here");
			recipe.Image = image.Content.ToArray();
		}
		return recipe;
	}
