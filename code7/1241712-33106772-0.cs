    //change your controller action
    [HttpGet]
    public ActionResult Index(int? id)
    {
    	if(id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    	
    	var model = new RecipeViewModel();
    	var data  = db.Recipes.Include(i => i.RecipeLines)
    					.Where(x=>x.RecipeId == id)
    					.ToList();
    					
    	model.RecipeLines = data;
    	return View(model);
    }
    
    //change your viewModel
    public class RecipeViewModel
    {
        public IEnumerable<RecipeModel> RecipeModels { get; set; }
    }
    
    
    //this is in the view
    @if (Model.RecipeLines != null)
    {
        foreach (var item in Model.RecipeModels.RecipeLines)
        {
            <p>
    			@item.Quantity 
    			@item.UnitOfMeasure 
    			@item.Ingredient
    		</p>
        }
    }
