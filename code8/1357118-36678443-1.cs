    public static void InsertIngredient(List<Ingredient> Ingredients, int recipeID)
            {
                IngredientDbContext ctx = new IngredientDbContext();
    
                foreach (var ingredient in Ingredients)
                {
                    Ingredient newItem = new Ingredient { IngredientID = ingredient.Ingredient,..., recipeID = recipeID};
                    ctx.Ingredient.Add(newItem);
                }
                ctx.SaveChanges();
            }
