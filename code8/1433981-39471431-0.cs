    public class EmailTagHelper : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var hasACertainKey = this.ViewContext.ViewData.ContainsKey("ACertainKey");
        }
    }
