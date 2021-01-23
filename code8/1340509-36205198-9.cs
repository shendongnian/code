    public class HideTaggedOperationsFilter : IDocumentFilter
    {
        private List<string> TagsToHide;
        public HideTaggedOperationsFilter()
        {
            TagsToHide = ConfigurationManager.AppSettings["TagsToHide"].Split(',').ToList();
        }
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            if (_tagsToHide == null) return;
            foreach (var apiDescription in apiExplorer.ApiDescriptions)
            {
                var tags = apiDescription.ActionDescriptor
                    .GetCustomAttributes<SwaggerTagAttribute>()
                    .Select(t => t.Tags)
                    .FirstOrDefault();
                if (tags == null || !_tagsToHide.Intersect(tags).Any())
                    continue;
                var route = "/" + apiDescription.Route.RouteTemplate.TrimEnd('/');
                swaggerDoc.paths.Remove(route);
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
