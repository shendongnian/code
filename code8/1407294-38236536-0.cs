    public static IHtmlString ImageActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName,
        object routeValues, object linkHtmlAttributes, AjaxOptions ajaxOptions, string imageSrc, object imageHtmlAttributes)
    {
        UrlHelper urlHelper = new UrlHelper(ajaxHelper.ViewContext.RequestContext);
    
        //Image tag
        TagBuilder imageTag = new TagBuilder("img");
        imageTag.Attributes.Add("src", VirtualPathUtility.ToAbsolute(imageSrc));
        imageTag.MergeAttributes(new RouteValueDictionary(imageHtmlAttributes), false);
    
        //Anchor tag
        TagBuilder anchorTag = new TagBuilder("a");
        anchorTag.InnerHtml = imageTag.ToString(TagRenderMode.SelfClosing);
        anchorTag.Attributes.Add("href", urlHelper.Action(actionName, controllerName, routeValues));
        // change the following line
        anchorTag.MergeAttributes(ajaxOptions.ToUnobtrusiveHtmlAttributes());
        // recommend the following change
        anchorTag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(linkHtmlAttributes)));
    
        return MvcHtmlString.Create(anchorTag.ToString());
    }
