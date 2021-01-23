    public class BeforeHeadScriptsShapeProvider : IShapeTableProvider
    {
        private readonly Work<IOrchardServices> orchardServices;
        public BeforeHeadScriptsShapeProvider(Work<IOrchardServices> orchardServices)
        {
            this.orchardServices = orchardServices;
        }
        public void Discover(ShapeTableBuilder builder)
        {
            builder.Describe("HeadScripts")
                .OnCreated(created =>
                {
                    orchardServices.Value.WorkContext.Layout.Head.Add(created.New.BeforeHeadScriptsShape());
                });
        }
        [Shape]
        public void BeforeHeadScriptsShape(HtmlHelper Html)
        {
            Html.ViewContext.Writer.WriteLine("<script type=\"text/javascript\"> alert('TEST');</script>");
        }
    }
