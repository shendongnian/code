    public static class ElementExtensions
    {
        public static void AsSelfClosing(this IElement element)
        {
            const int SelfClosing = 0x1;
    
            var type = typeof(IElement).Assembly.GetType("AngleSharp.Dom.Node");
            var field = type.GetField("_flags", BindingFlags.Instance | BindingFlags.NonPublic);
    
            var flags = (uint)field.GetValue(element);
            flags |= SelfClosing;
            field.SetValue(element, Enum.ToObject(field.FieldType, flags));
        }
    }
    
    public class CustomHtmlMarkupFormatter : IMarkupFormatter
    {
        public static readonly CustomHtmlMarkupFormatter Instance = new CustomHtmlMarkupFormatter();
    
        public string Text(String text) => HtmlMarkupFormatter.Instance.Text(text);
        public string Comment(IComment comment) => HtmlMarkupFormatter.Instance.Comment(comment);
        public string Processing(IProcessingInstruction processing) => HtmlMarkupFormatter.Instance.Processing(processing);
        public string Doctype(IDocumentType doctype) => HtmlMarkupFormatter.Instance.Doctype(doctype);
        //public string OpenTag(IElement element, Boolean selfClosing) => HtmlMarkupFormatter.Instance.OpenTag(element, selfClosing);
        public string CloseTag(IElement element, Boolean selfClosing) => HtmlMarkupFormatter.Instance.CloseTag(element, selfClosing);
        public string Attribute(IAttr attribute) => HtmlMarkupFormatter.Instance.Attribute(attribute);
    
        public string OpenTag(IElement element, Boolean selfClosing)
        {
            var temp = new StringBuilder();
            temp.Append('<');
    
            if (!String.IsNullOrEmpty(element.Prefix))
            {
                temp.Append(element.Prefix).Append(':');
            }
    
            temp.Append(element.LocalName);
    
            foreach (var attribute in element.Attributes)
            {
                temp.Append(" ").Append(Instance.Attribute(attribute));
            }
    
            temp.Append(selfClosing ? " />" : ">");
    
            return temp.ToString();
        }
    }
