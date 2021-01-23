    public class ContactViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var htmlString = new HtmlString("<b>Hello World!</b>");
            return new HtmlContentViewComponentResult(htmlString);
        }
    }
