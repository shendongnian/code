    /// <summary>
    /// Internal method that handles rendering of either partial or 
    /// or full views.
    /// </summary>
    /// <param name="viewPath">
    /// The path to the view to render. Either in same controller, shared by 
    /// name or as fully qualified ~/ path including extension
    /// </param>
    /// <param name="model">Model to render the view with</param>
    /// <param name="partial">Determines whether to render a full or partial view</param>
    /// <returns>String of the rendered view</returns>
    protected string RenderViewToStringInternal(string viewPath, object model,
                                                bool partial = false)
    {
        // first find the ViewEngine for this view
        ViewEngineResult viewEngineResult = null;
        if (partial)
            viewEngineResult = ViewEngines.Engines.FindPartialView(Context, viewPath);
        else
            viewEngineResult = ViewEngines.Engines.FindView(Context, viewPath, null);
        if (viewEngineResult == null)
            throw new FileNotFoundException(Resources.ViewCouldNotBeFound);
        // get the view and attach the model to view data
        var view = viewEngineResult.View;
        Context.Controller.ViewData.Model = model;
        string result = null;
        using (var sw = new StringWriter())
        {
            var ctx = new ViewContext(Context, view,
                                        Context.Controller.ViewData,
                                        Context.Controller.TempData,
                                        sw);
            view.Render(ctx, sw);
            result = sw.ToString();
        }
        return result;
    }
