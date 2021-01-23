        protected override void Seed(henrikntest13Context context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = "1", Text = "First item", Complete = false },
                new TodoItem { Id = "2", Text = "Second item", Complete = false },
            };
            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }
            List<MyModel> myModels = new List<MyModel>
            {
                new MyModel { Id = "1", MyData = "First Item"},
                new MyModel { Id = "2", MyData = "Second Item"},
            };
            foreach (MyModel model in myModels)
            {
                context.Set<MyModel>().Add(model);
            }
            base.Seed(context);
        }
