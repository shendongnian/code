    using Microsoft.AspNet.Mvc.Rendering;
    using Microsoft.AspNet.Mvc.ViewFeatures;
    using Microsoft.AspNet.Razor.TagHelpers;
    using System.Linq;
    
    namespace WebApplication1.TagHelpers
    {
        [HtmlTargetElement("edit")]
        public class EditTagHelper : TagHelper
        {
            [HtmlAttributeName("asp-for")]
            public ModelExpression aspFor { get; set; }
    
            [ViewContext]
            [HtmlAttributeNotBound]
            public ViewContext ViewContext { get; set; }
    
            protected IHtmlGenerator _generator { get; set; }
    
            public EditTagHelper(IHtmlGenerator generator)
            {
                _generator = generator;
            }
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                var propName = aspFor.ModelExplorer.Model.ToString();
                var modelExProp = aspFor.ModelExplorer.Container.Properties.Single(x => x.Metadata.PropertyName.Equals(propName));
                var propValue = modelExProp.Model;
                var propEditFormatString = modelExProp.Metadata.EditFormatString;
    
                var label = _generator.GenerateLabel(ViewContext, aspFor.ModelExplorer,
                    propName, propName, new { @class = "col-md-2 control-label", @type = "email" });
    
                var input = _generator.GenerateTextBox(ViewContext, aspFor.ModelExplorer,
                    propName, propValue, propEditFormatString, new { @class = "form-control" });
    
                var validation = _generator.GenerateValidationMessage(ViewContext, aspFor.ModelExplorer, 
                    propName, string.Empty, string.Empty, new { @class = "text-danger" });
    
                var inputParent = new TagBuilder("div");
                inputParent.AddCssClass("col-md-10");
                inputParent.InnerHtml.Append(input);
                inputParent.InnerHtml.Append(validation);
    
                var parent = new TagBuilder("div");
                parent.AddCssClass("form-group");
                parent.InnerHtml.Append(label);
                parent.InnerHtml.Append(inputParent);
    
                output.Content.SetContent(parent);
                base.Process(context, output);
            }
        }
    }
