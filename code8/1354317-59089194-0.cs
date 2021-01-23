    public IViewComponentResult Invoke(object arguments)
    {
        return new HtmlContentViewComponentResult(
            new HtmlString("<ul><li>My HTML code</li></ul>"));
    }
