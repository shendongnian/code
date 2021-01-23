    c.OperationFilter<CsrfOperationFilter>();
     
    public class CsrfOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Applies the specified operation.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="context">The context.</param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (string.Equals(context.ApiDescription.HttpMethod, "Get", System.StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }
            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "csrf_token",
                In = "header",
                Type = "string",
                Required = true,
            });
        }
    }
