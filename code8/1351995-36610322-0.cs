    public class CategorizeFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            string path = context.ApiDescription.RelativePath;
            string segment = path.Split('/')[1];
            if (segment != context.ApiDescription.GroupName)
            {
                operation.Tags = new List<string> { segment };
            }
        }
    }
