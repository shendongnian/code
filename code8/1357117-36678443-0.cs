    public static int InsertRecipe(Recipe recipe)
                {
                    RecipeDbContext ctx = new RecipeDbContext();
                    ctx.Recipes.Add(recipe);
                    ctx.SaveChanges();
                    return recipe.recipeID;
                }
