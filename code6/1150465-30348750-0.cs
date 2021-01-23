    namespace TestingTagHelpers.TagHelpers
    {
        using Microsoft.AspNet.Razor.Runtime.TagHelpers;
        using System;
    
        /// <summary>
        /// <see cref="ITagHelper"/> implementation targeting &lt;demo&gt; elements.
        /// </summary>
        //[TargetElement("demo")]
        public class DemoTagHelper : TagHelper
        {
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                var childContent = context.GetChildContentAsync().Result;
                string demoContent = childContent.GetContent();
                string demo = context.AllAttributes["asp-custom"].ToString();
    
                output.TagName = "div";
                output.Attributes.Clear();
                output.Attributes["data-custom"] = demo;
                output.Content.SetContent(demoContent);
            }
        }
    }
