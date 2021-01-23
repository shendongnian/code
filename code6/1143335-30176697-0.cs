    namespace ActivatorWebSite.TagHelpers
    {
        [TargetElement("body")]
        public class FooterTagHelper : TagHelper
        {
            [Activate] // here
            IApplicationEnvironment ApplicationEnvironment { get; set; }
            [Activate] // and here
            public IHtmlHelper HtmlHelper { get; set; }
    
            [Activate] // and here
            public ViewDataDictionary ViewData { get; set; }
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                output.PostContent.SetContent($"<footer>{HtmlHelper.Encode(ViewData["footer"])}</footer>");
            }
        }
    }
