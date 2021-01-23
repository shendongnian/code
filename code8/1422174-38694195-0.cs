    var viewModels = new List<TodoViewModel>();
    using (TestDb db = new TestDb())
    {
        var todoModels = db.ToDos.Where(todo => todo.UserId == id).ToList();
        foreach (var model in todoModels)
        {
            var todoViewModel = new TodoViewModel
            {
                // Populate viewmodel properties here
                Text = model.Text
            };
 
            viewModels.Add(todoViewModel);
        }
    }
    return Json(viewModels, JsonRequestBehavior.AllowGet);
