    public ActionResult Survey(int SurveyId) 
    {
      var vm = new SurveyViewModel();
    
         using (var db = new SurveyContext())
         {
             vm.Projects = db.Projects.Include("Items")
                             .Include("Items.Category")
                             .Where(s => s.SurveyId == SurveyId).ToList();
    
             vm.OrderedItems  = from s in Surveys
                                  from i in s.Project.Items
                                  from io in i.ItemOrders
                                  where s.Id == SurveyId
                                  orderby io.ItemOrder
                               select new OrderedItem {
                                    Id = i.Id,
                                    Category = i.Category.Category,
                                    Order = io.Order,
                                    ItemText = i.Text.Text
                                  }).Distinct().ToList();
         }
         return View(vm);
    }
