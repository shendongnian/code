    public ActionResult SomeAction(int id)
    {
        var model = ModelRepostiory.GetById(id);
        var viewModel = new MainViewModel
        {
            Baz = model.Baz,
            Qux = new PartialViewModel
            {
                Foo = model.Partial.Foo,
                Bar = model.Partial.Bar,
            },
        };
        return View(viewModel);
    }
