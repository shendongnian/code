    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System.Linq;
    public class SwaggerParameterAttributeFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var attributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<SwaggerParameterAttribute>();
            foreach (var attribute in attributes)
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = attribute.Name,
                    Description = attribute.Description,
                    In = attribute.ParameterType,
                    Required = attribute.Required,
                    Type = attribute.DataType
                });              
        }
    }
