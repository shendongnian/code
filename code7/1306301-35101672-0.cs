    public ActionResult Browse(string gemCategory = "")
    {
    	var category = db.Categories.FirstOrDefault(p => p.Name == gemCategory);
    
    	var gemstones = db.Gemstones.Include(s => s.Shapes)
    								.Include(c => c.Clarities)
    								.Include(c => c.Categories)
    								.Include(c => c.Cuts)
    								.Include(c => c.Orgins)
    								.Where(p => p.CategoryID == category.CategoryID);
    													
    	var viewModel = new StoreBrowseViewModel() {Gemstones = gemstones};
    			
    	return View(viewModel);
    }
