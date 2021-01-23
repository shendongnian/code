        public ActionResult ShowSelectionList(int? categoryid)
        {
            // Save the selected category
            ViewBag.categoryId = categoryid;
             // Get the categories to display
            var viewModel = (from c in categoryrepository.Categories
                             select new CategorySelectionPartialViewModel()
                             {
                                 CategoryID = c.CategoryID,
                                 Description = c.Description
                             }).AsEnumerable();
     
            // Return the partial view
            return PartialView("_Categories", viewModel);
        }
