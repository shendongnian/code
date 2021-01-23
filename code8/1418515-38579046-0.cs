    public void WriteToFile(ContextDB db, DataViewModel model, string fileName)
    {
        string html = RenderView(model);
        File.WriteAllText(fileName, html);
    }
    private string RenderView(model)
    {
        using(var controller = ViewRenderer.CreateController<DetailsController>())
        {
            return ViewRenderer.RenderView("~/Views/Details/Template.cshtml", 
                model, controller.ControllerContext);
        }
    }
