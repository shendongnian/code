    [HtmlTargetElement("options", Attributes = "asp-items")]
    public class OptionsTagHelper : TagHelper
    {
        public OptionsTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }
        [HtmlAttributeNotBound]
        public IHtmlGenerator Generator { get; set; }
        [HtmlAttributeName("asp-items")]
        public object Items { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.SuppressOutput();
            // Is this <options /> element a child of a <select/> element the SelectTagHelper targeted?
            object formDataEntry;
            context.Items.TryGetValue(typeof(SelectTagHelper), out formDataEntry);
            var selectedValues = formDataEntry as ICollection<string>;
            var encodedValues = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (selectedValues != null && selectedValues.Count != 0)
            {
                foreach (var selectedValue in selectedValues)
                {
                    encodedValues.Add(Generator.Encode(selectedValue));
                }
            }
            IEnumerable<SelectListItem> items = null;
            if (Items != null)
            {
                if (Items is IEnumerable)
                {
                    var enumerable = Items as IEnumerable;
                    if (Items is IEnumerable<SelectListItem>)
                        items = Items as IEnumerable<SelectListItem>;
                    else if (Items is IEnumerable<IIntegerListItem>)
                        items = ((IEnumerable<IIntegerListItem>)Items).Select(x => new SelectListItem() { Selected = false, Value = x.Value.ToString(), Text = x.Text });
                    else
                        throw new InvalidOperationException(string.Format("The {2} was unable to provide metadata about '{1}' expression value '{3}' for <options>.",
                            "<options>",
                            "ForAttributeName",
                            nameof(IModelMetadataProvider),
                            "For.Name"));
                }
                else
                {
                    throw new InvalidOperationException("Invalid items for <options>");
                }
                foreach (var item in items)
                {
                    bool selected = (selectedValues != null && selectedValues.Contains(item.Value)) || encodedValues.Contains(item.Value);
                    var selectedAttr = selected ? "selected='selected'" : "";
                    if (item.Value != null)
                        output.Content.AppendHtml($"<option value='{item.Value}' {selectedAttr}>{item.Text}</option>");
                    else
                        output.Content.AppendHtml($"<option>{item.Text}</option>");
                }
            }
        }
    }
