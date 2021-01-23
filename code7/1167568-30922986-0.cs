    var foodItem = new FoodItem();
    dataContext.AddToFoods(foodItem);	// Add to context before populating fields so the values are tracked.
    foodItem = Mapper.Map(newFood, foodItem);
    
    // DataValue Properties like StateValue objects can now be added since it is tracked by the context.
    var state = StateValue.CreateStateValue("Montana");
    foodItem.StateValue = state;
    
    // Need to link special DataServiceCollection lists like Ingredient using a reference.
    if (newFood.Ingredient != null)
    {
    	newFood.Ingredient.ForEach(c =>
    	{
    		var ingredient = FoodIngredient.CreateFoodIngredientValue(c);
    		dataContext.AttachTo("FoodIngredientValue", ingredient);
    		foodItem.FoodIngredient.Add(ingredient);
    		dataContext.AddLink(foodItem, "FoodIngredient", ingredient);
    	});
    }
