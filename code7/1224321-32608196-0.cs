    public class BeforeHeadScriptsShapeProvider : IShapeTableProvider
    {
        private readonly IOrchardServices orchardServices;
        public BeforeHeadScriptsShapeProvider(IOrchardServices orchardServices)
        {
            this.orchardServices = orchardServices;
        }
        public void Discover(ShapeTableBuilder builder)
        {
            builder.Describe("HeadScripts")
                .OnCreated(created =>
                {
                    orchardServices.WorkContext.Layout.Head.Add(created.New.BeforeHeadScriptsShape());
                });
        }
        [Shape]
        public void BeforeHeadScriptsShape(HtmlHelper Html)
        {
            Html.ViewContext.Writer.WriteLine("<script type=\"text/javascript\"> alert('TEST');</script>");
        }
    }
