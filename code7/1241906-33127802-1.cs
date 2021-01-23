     class RecipeLineCustomBinder : DefaultModelBinder
        {
            private RecipeApplicationDb db = new RecipeApplicationDb();
    
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;
               
                // Get the QuantityCustomIngredient from the webform. 
                string quantityUomIngredient = request.Form.Get("QuantityUomIngredient");
                // Get the IngredientID from the webform.
                int recipeID = int.Parse(request.Form.Get("RecipeId"));
                // Split the QuantityCustomIngredient into seperate strings. 
                string[] quantityUomIngredientArray = quantityUomIngredient.Split();
                //string[] quantityUomIngredientArray = quantityUomIngredient.Split(new string[] { " " }, 2, StringSplitOptions.RemoveEmptyEntries);
    
                if (quantityUomIngredientArray.Length >= 3)
                {
                    // Get the quantity value
                    double quantityValue;
                    bool quantity = double.TryParse(quantityUomIngredientArray[0], out quantityValue);
    
                    // Get the UOM value. 
                    string uom = quantityUomIngredientArray[1];
                    UnitOfMeasureModel unitOfMeasure = null;
                    bool checkUOM = (from x in db.UnitOfMeasures
                                     where x.Abbreviation == uom
                                     select x).Count() > 0;
                    if (checkUOM)
                    {
                        unitOfMeasure = (from x in db.UnitOfMeasures
                                         where x.Abbreviation == uom
                                         select x).FirstOrDefault();
                    }
    
                    // Get the ingredient out of the array.
                    string ingredient = "";
                    for (int i = 2; i < quantityUomIngredientArray.Length; i++)
                    {
                        ingredient += quantityUomIngredientArray[i];
                        if (i != quantityUomIngredientArray.Length - 1)
                        {
                            ingredient += " ";
                        }
                    }
    
                    bool checkIngredient = (from x in db.Ingredients where x.Name == ingredient select x).Count() > 0;
                    IngredientModel Ingredient = null;
                    if (checkIngredient)
                    {
                        Ingredient = (from x in db.Ingredients
                                      where x.Name == ingredient
                                      select x).FirstOrDefault();
                    }
    
                    // Return the values. 
                    return new RecipeLine
                    {
                        Quantity = quantityValue,
                        UnitOfMeasure = unitOfMeasure,
                        Ingredient = Ingredient,
                        RecipeId = recipeID
                };
                }
                else
                {
                    return null;
                }
                
            }
        }
