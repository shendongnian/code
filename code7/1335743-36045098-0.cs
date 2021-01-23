    public ActionResult AddIngridient(int id = 0)
    {
        LoadViewBag();
        return View(new Ingredients { IngredientID = id });
    }
    
    [HttpPost]
    public ActionResult AddIngridient(Ingredients ingridients)
    {
        if (ModelState.IsValid)
        {
            FRE.Ingredients.Add(ingridients);
            FRE.SaveChanges();
            return RedirectToAction("Index");
        }
        LoadViewBag();
        return View(ingridients);
    }
    
    private void LoadViewBag()
    {
        IEnumerable<Ingredient> ListOfIngridient = FRE.Ingredient.Select(key => key).ToList();
        ViewBag.IngridientsList = new SelectList(ListOfIngridient, "IngredientID", "IngredientName");
    
        IEnumerable<Amount> ListOfAmounts = FRE.Amount.Select(key => key).ToList();
        ViewBag.AmountsList = new SelectList(ListOfAmounts, "AmountID", "AmountName");
    }
