     [HttpPost]
         public ActionResult Save(MyModelView model)
         {
           foreach (string skill in model.SelectedSkills){//Selected Skills. Save to database}
         }
        
