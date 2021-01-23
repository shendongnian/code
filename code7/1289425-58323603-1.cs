    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DigitScpi.Web.Helpers;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    
    namespace TagHelpers
    {
        /// Generates the radio buttons for an enum. Syntax: `<input radio asp-for="MyMappedEnumField"/>`.
        [HtmlTargetElement("input", Attributes = RadioAttributeName)]
        public class RadioButtonTagHelper : TagHelper
        {
            private const string RadioAttributeName = "radio";
            private const string ForAttributeName = "asp-for";
    
            [HtmlAttributeNotBound] [ViewContext] public ViewContext ViewContext { get; set; }
            private readonly IHtmlGenerator _generator;
            
            [HtmlAttributeName(ForAttributeName)] public ModelExpression For { get; set; }
            [HtmlAttributeName(RadioAttributeName)] public bool RadioMarker { get; set; }
            
            public RadioButtonTagHelper(IHtmlGenerator generator)
            {
                _generator = generator;
            }
    
            /// <inheritdoc />
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                output.SuppressOutput();
    
                foreach (var enumItem in For.Metadata.EnumNamesAndValues)
                {
                    var id = VariantId(enumItem);
                    var name = For.Metadata.EnumGroupedDisplayNamesAndValues.FirstOrDefault(v => v.Value == enumItem.Value).Key.Name;
                    var radio = _generator.GenerateRadioButton(ViewContext, For.ModelExplorer, For.Name, enumItem.Key, false, new {id});
                    var label = _generator.GenerateLabel(ViewContext, For.ModelExplorer, For.Name, name, new {@for = id});
    
                    output.PreElement.AppendHtml(radio);
                    output.PreElement.AppendHtml(label);
                }
            }
    
            /// Computes the variant to be unique for each radiobutton.
            private string VariantId(KeyValuePair<string, string> enumItem) =>
                new StringBuilder()
                    .Append(ViewContext.CreateUniqueId(_generator.IdAttributeDotReplacement, For.Name))
                    .Append(_generator.IdAttributeDotReplacement)
                    .Append(enumItem.Key)
                    .ToString();
        }
    }
