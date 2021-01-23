    public class MyFormGroupTagHelper : PartialTagHelper
    {
        public MyFormGroupTagHelper(ICompositeViewEngine viewEngine, IViewBufferScope viewBufferScope) : base(viewEngine, viewBufferScope)
        { }
        public ModelExpression Property { get; set; }
        public string LabelText { get; set; } = null;
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.For = Property;
            this.Name = "_FormGroup";
            // Have to use Viewdata to pass information to the partial view, because the model is the single property of the entity that will be posted back to the controller
            this.ViewData["TH_LabelText"] = LabelText;
            this.ViewData["TH_DataTypeName"] = Property.Metadata.DataTypeName;
            await base.ProcessAsync(context, output);
        }
    }
