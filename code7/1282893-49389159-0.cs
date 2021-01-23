    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    [HtmlTargetElement("my-tag")]
    public class MyTagHelper : TagHelper {
        private readonly IUrlHelperFactory urlHelperFactory;
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public MyTagHelper (IUrlHelperFactory urlHelperFactory) {
            this.urlHelperFactory = urlHelperFactory;
        }
        
        public override void Process(TagHelperContext context, TagHelperOutput output) {
            var urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
        }
    }
