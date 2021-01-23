    public class TagBuilder : IHtmlContent
    {
        ...
        public void SetInnerText(string innerText)
        {
            InnerHtml = new StringHtmlContent(innerText);
        }
        ...
    }
