    private IUrlHelper urlHelper;
    ...
    public MainMenuLinkTagHelper (IUrlHelper urlHelper)
    {
        this.urlHelper = urlHelper;
    }
    ...
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        output.Attributes.Add("href", this.urlHelper.Action(this.Action, this.Controller));
        output.Content.SetHtmlContent("Click me");
    } 
