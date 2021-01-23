    public class HideTaggedOperationsFilter : IDocumentFilter
    {
        private List<string> TagsToHide;
        public HideTaggedOperationsFilter()
        {
            TagsToHide = ConfigurationManager.AppSettings["TagsToHide"].Split(',').ToList();
        }
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            foreach (var apiDescription in apiExplorer.ApiDescriptions)
            {
                var tags = apiDescription.ActionDescriptor
                    .GetCustomAttributes<SwaggerTagAttribute>()
                    .Select(t => t.Tags)
                    .FirstOrDefault();
                if (tags != null && TagsToHide.Intersect(tags).Any())
                {
                    PathItem path;
                    if (swaggerDoc.paths.TryGetValue("/" + apiDescription.Route.RouteTemplate, out path))
                    {
                        path.post = null;
                        path.get = null;
                        path.put = null;
                        path.delete = null;
                        path.head = null;
                    }
                }
            }
        }
    }
    public class SwaggerTagAttribute : Attribute
    {
        public string[] Tags { get; }
        public SwaggerTagAttribute(params string[] tags)
        {
            this.Tags = tags;
        }
    }
