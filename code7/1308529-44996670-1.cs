    /// <summary>
    /// <see cref="ITagHelper"/> implementation targeting &lt;p&gt; elements with an <c>asp-for</c> attribute.
    /// </summary>
    [HtmlTargetElement("p", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("div", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("dd", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("span", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("th", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("td", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("span", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("i", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("h1", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("h2", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("h3", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("h4", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("h5", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("h6", Attributes = ModelValueForAttributeName)]
    [HtmlTargetElement("code", Attributes = ModelValueForAttributeName)]
    public class ModelValueForTagHelper : TagHelper
    {
        private const string ModelValueForAttributeName = "asp-for-display";
        [HtmlAttributeName(ModelValueForAttributeName)]
        public ModelExpression For { get; set; }
        public int length { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ***// If you need clear result use "TagName = "";"***
            //output.TagName = "label";
            //output.TagMode = TagMode.StartTagAndEndTag;
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }
            var text = For.ModelExplorer.GetSimpleDisplayText();
            if (text.Length >= length)
            {
                text = text.Substring(0, length) + "...";
            }
            output.Content.SetContent(text);
        }
    }
