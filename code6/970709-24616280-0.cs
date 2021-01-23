    public class Recipe
    {
      public int RecipeId {get; set;}
      public List<Ingredients> Ingredient {get; set;}
    } 
    
    public class Ingredients
    {
      public string Name {get; set;}
      public string Amount {get; set;}
    }
    public ActionResult Index()
    {
       Recipe model = new Recipe();
       model.RecipeId = 1;
       model.Ingredient = new List<Ingredients>();
       model.Ingredient.Add(new Ingredients{Name = "Salt", 
                                            Amount = "A Pinch"});
       model.Ingredient.Add(new Ingredients{Name = "Hot Sauce", 
                                            Amount = "HOT HOT HOT!"});   
      return View(model);
    }
