    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        ....
        output.PreElement.SetHtmlContent("<div class='row'><div class='form-control'>");
        output.PostElement.SetHtmlContent("</div></div>");
    }
