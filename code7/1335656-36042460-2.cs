    public ActionResult AddIngridient(int id = 0)
    {
        IEnumerable<Ingredient> ListOfIngridient =  FRE.Ingredient.Select(key => key).ToList();
        ViewBag.IngridientsList = new SelectList(ListOfIngridient,"IngredientID", "IngredientName");
    
        IEnumerable<Amount> ListOfAmounts = FRE.Amount.Select(key => key).ToList();
        ViewBag.AmountsList = new SelectList(ListOfAmounts, "AmountID", "AmountName");
    
        return View(new Ingredients { IngredientID = id });
    }
