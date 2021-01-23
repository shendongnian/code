    [HttpPost]
            public ActionResult Create(RecipeV model, List<Ingredient> ingredient, List<Direction> direction)
            {
    
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
               // do something
                //Direct the user to the index page. 
                return RedirectToAction("index", "Recipes", new { id = recipe.RecipeID });
            }
   
