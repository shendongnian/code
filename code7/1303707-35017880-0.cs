        public ActionResult MyData()
            {
                List<NewListViewModel> newList = 
                     db.oldList.Select(x=>new NewListViewModel { Name = x.Name}).ToList();
        
                return View(newList);
            }
