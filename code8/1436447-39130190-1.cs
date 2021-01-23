            if (!ModelState.IsValid)
            {
                return View(model);
            }
           // do something
            //Direct the user to the index page. 
            return RedirectToAction("index", "Recipes", new { id = recipe.RecipeID });
        }
   
