    public static class HtmlHelperExtensions
    {
       
        public static MvcHtmlString ActionImageLink(this HtmlHelper helper, string controller, string action, object parameters, object linkHtmlAttributes, string src, object imageHtmlAttributes)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var url = String.IsNullOrWhiteSpace(controller) ? action : urlHelper.Action(action, controller, parameters);
            var imgTagBuilder = new TagBuilder("img");
            var imgUrl = urlHelper.Content(src);
                        
            imgTagBuilder.MergeAttribute("src", imgUrl);
            if (imageHtmlAttributes != null)
            {
                var props = imageHtmlAttributes.GetType().GetProperties();
                props.ToList().ForEach(prop => { imgTagBuilder.MergeAttribute(
                    prop.Name,
                    imageHtmlAttributes.GetType().GetProperty(prop.Name).GetValue(imageHtmlAttributes, null) as String);
                });
            }
            var image = imgTagBuilder.ToString(TagRenderMode.SelfClosing);
            var aTagBuilder = new TagBuilder("a");
            aTagBuilder.MergeAttribute("href", url);
            if (linkHtmlAttributes != null)
            {
                var props = linkHtmlAttributes.GetType().GetProperties();
                props.ToList().ForEach(prop =>
                {
                    aTagBuilder.MergeAttribute(
                        prop.Name,
                        linkHtmlAttributes.GetType().GetProperty(prop.Name).GetValue(linkHtmlAttributes, null) as String);
                });
            }
            aTagBuilder.InnerHtml = image;
            return MvcHtmlString.Create(aTagBuilder.ToString());
        }}
