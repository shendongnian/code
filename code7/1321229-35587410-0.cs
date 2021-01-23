    public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
    {
        var fragment = ... // access URL via controllerContext
        var preferred = ViewLocationFormats.Where(x => x.Contains(fragment)).ToList();
        // return retult from preferred or fall back to base.FindView
    }
