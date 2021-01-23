    var ingredients = ingredientList.ToLower().Split(new [] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
    var predicate = PredicateBuilder.False<Recipe>();
    foreach (var ingredient in ingredients)
    {
        string temp = ingredient;  // To avoid passing the loop variable into a closure
        predicate = predicate.Or(r => r.Ingredients.Contains(temp);
    }
    reportQuery = reportQuery.Where(predicate);
