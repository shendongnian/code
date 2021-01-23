    public ActionResult TestViewWithModel(string id)
    {
        var model = new TestViewModel {DocTitle = id, DocContent = "This is a test"};
        return new ViewAsPdf(model);
    }
    public ActionResult PrintIndex()
    {
        return new ActionAsPdf("Index", new { name = "Giorgio" }) { FileName = "Test.pdf" };
    }
