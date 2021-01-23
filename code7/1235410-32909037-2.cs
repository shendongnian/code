    private void orderPizza_Click( object sender, EventArgs e )
    {
      var selectedIngredients =
        new List<Ingredient>
        (
          checkedListBoxIngredients
          .CheckedItems
          .Cast<Ingredient>()
        );
     
      var ingredientPrice = selectedIngredients.Sum( i=> i.Cost );
    
      //--> complete the order...
    }
