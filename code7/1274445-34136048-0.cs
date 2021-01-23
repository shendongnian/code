    public static class HtmlHelpers
    {
        public static MvcHtmlString RenderPicture(this HtmlHelper helper, IPictureElement picture)
        {
            return new MvcHtmlString(picture.ToString());
        }
    }
