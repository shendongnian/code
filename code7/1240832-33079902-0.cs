    protected override void Seed(RecipeApplication.Models.RecipeApplicationDb context)
    {
        var defaultUOM = new UnitOfMeasureModel { Name = "Gram", Abbreviation = "g" };
        if (!context.UnitOfMeasures.Any())
        {
            context.UnitOfMeasures.AddOrUpdate(
                u => u.Id,
                defaultUOM,
                new UnitOfMeasureModel { Name = "Kilogram", Abbreviation = "kg"},
                new UnitOfMeasureModel { Name = "Milligram", Abbreviation = "mg" }
                );
        }
        if (!context.Ingredients.Any())
        {
            context.Ingredients.AddOrUpdate(
                i => i.Id,
                new IngredientModel { Name = "Italiaanse Ham", DefaultUOM = defaultUOM
                );
        }
    }
