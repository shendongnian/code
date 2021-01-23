    private List<Rezept> recipes = new List<Rezept>();
    private List<Zutaten> ingredients = new List<Zutaten>();
    private void AddIngredient()
    {
        var i = new Zutaten();
        ingredients.Add(i);
    }
    private void AddRecipe()
    {
        var r = new Rezept("My Recipe", ingredients);
        ingredients = new List<Zutaten>();
        recipes.Add(r);
    }
