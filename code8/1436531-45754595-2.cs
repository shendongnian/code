    [HtmlTargetElement("big-ul", Attributes = IterateOverAttr)]
    public class BigULTagHelper : TagHelper
    {
        private const string IterateOverAttr = "iterateover";
        [HtmlAttributeName(IterateOverAttr)]
        public IEnumerable<object> IterateOver { get; set; }
        
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            output.TagMode = TagMode.StartTagAndEndTag;
            
            foreach(var item in IterateOver)
            {
                // this is the key line: we pass the list item to the child tag helper
                context.Items["item"] = item;
                output.Content.AppendHtml(await output.GetChildContentAsync(false));
            }
        }
    }
    [HtmlTargetElement("little-li")]
    public class LittleLiTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // retrieve the item from the parent tag helper
            var item = context.Items["item"] as Employee;
            output.TagName = "li";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.AppendHtml($"<span>{item.Name}</span><span>{item.LastName}</span>");
        }
    }
