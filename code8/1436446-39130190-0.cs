            if (!ModelState.IsValid)
            {
                return View(recipe);
            }
            recipe.Date = DateTime.Now;
            // Add the new recipe to the recipes table.
            db.Recipes.InsertOnSubmit(recipe);
            db.SubmitChanges();
            int id = recipe.RecipeID;
            foreach (Ingredient i in ingredient)
            {
                if (i.Text != null)
                {
                    i.RecipeID = id;
                    db.Ingredients.InsertOnSubmit(i);
                    db.SubmitChanges();
                }
            }
            foreach (Direction d in direction)
            {
                if (d.Text != null)
                {
                    d.RecipeID = id;
                    db.Directions.InsertOnSubmit(d);
                    db.SubmitChanges();
                }
            }
            //Direct the user to the index page. 
            return RedirectToAction("index", "Recipes", new { id = recipe.RecipeID });
        }
   
