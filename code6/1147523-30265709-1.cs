    [TargetElement("span", Attributes = AttributeName)]
    public class YourTagHelper : TagHelper
    {
        private const string AttributeName = "your-for";
        [Activate]
        protected internal ViewContext ViewContext { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var modelState = ViewContext.ViewData.ModelState;
            // Your logic here
        }
    }
