    /// <summary>
    /// Add enum value descriptions to Swagger
    /// </summary>
    public class EnumDocumentFilter : IDocumentFilter {
        /// <inheritdoc />
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context) {
            // add enum descriptions to result models
            foreach (var schemaDictionaryItem in swaggerDoc.Definitions) {
                var schema = schemaDictionaryItem.Value;
                foreach (var propertyDictionaryItem in schema.Properties) {
                    var property = propertyDictionaryItem.Value;
                    var propertyEnums = property.Enum;
                    if (propertyEnums != null && propertyEnums.Count > 0) {
                        property.Description += DescribeEnum(propertyEnums);
                    }
                }
            }
            if (swaggerDoc.Paths.Count <= 0) return;
            // add enum descriptions to input parameters
            foreach (var pathItem in swaggerDoc.Paths.Values) {
                DescribeEnumParameters(pathItem.Parameters);
                // head, patch, options, delete left out
                var possibleParameterisedOperations = new List<Operation> {pathItem.Get, pathItem.Post, pathItem.Put};
                possibleParameterisedOperations.FindAll(x => x != null)
                    .ForEach(x => DescribeEnumParameters(x.Parameters));
            }
        }
        private static void DescribeEnumParameters(IList<IParameter> parameters) {
            if (parameters == null) return;
            foreach (var param in parameters) {
                if (param.Extensions.ContainsKey("enum") && param.Extensions["enum"] is IList<object> paramEnums &&
                    paramEnums.Count > 0) {
                    param.Description += DescribeEnum(paramEnums);
                }
            }
        }
        private static string DescribeEnum(IEnumerable<object> enums) {
            var enumDescriptions = new List<string>();
            Type type = null;
            foreach (var enumOption in enums) {
                if (type == null) type = enumOption.GetType();
                enumDescriptions.Add($"{Convert.ChangeType(enumOption, type.GetEnumUnderlyingType())} = {Enum.GetName(type, enumOption)}");
            }
            return $"{Environment.NewLine}{string.Join(Environment.NewLine, enumDescriptions)}";
        }
    }
