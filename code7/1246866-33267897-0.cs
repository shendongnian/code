    ViewBag.CategoryId = new SelectList(
         db.Categories
           .Include("Problem") // eager load
           .Where(c => c.Status == 1)
           .OrderBy(c => c.Problem.ProblemName)
           .ToList(), // enumerate 
         "CategoryId", 
         "FullCategory");
