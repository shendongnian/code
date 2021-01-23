    public class AuthorizeRoleFilter : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                IPrincipal user = HttpContext.Current.User;
    
                foreach (ApiDescription apiDescription in apiExplorer.ApiDescriptions)
                {
                    var authorizeAttributes = apiDescription
                        .ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>().ToList();
                    authorizeAttributes.AddRange(apiDescription
                        .ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AuthorizeAttribute>());
    
                    if (!authorizeAttributes.Any())
                        continue;
    
                    var roles =
                        authorizeAttributes
                            .SelectMany(attr => attr.Roles.Split(','))
                            .Distinct()
                            .ToList();
                    if (!user.Identity.IsAuthenticated || !roles.Any(role => user.IsInRole(role) || role == ""))
                    {
                        string key = "/" + apiDescription.RelativePath;
                        PathItem pathItem = swaggerDoc.paths[key];
                        switch (apiDescription.HttpMethod.Method.ToLower())
                        {
                            case "get":
                                pathItem.get = null;
                                break;
                            case "put":
                                pathItem.put = null;
                                break;
                            case "post":
                                pathItem.post = null;
                                break;
                            case "delete":
                                pathItem.delete = null;
                                break;
                            case "options":
                                pathItem.options = null;
                                break;
                            case "head":
                                pathItem.head = null;
                                break;
                            case "patch":
                                pathItem.patch = null;
                                break;
                        }
                        if (pathItem.get == null &&
                            pathItem.put == null &&
                            pathItem.post == null &&
                            pathItem.delete == null &&
                            pathItem.options == null &&
                            pathItem.head == null &&
                            pathItem.patch == null)
                        {
                            swaggerDoc.paths.Remove(key);
                        }
                    }
                }
    
                swaggerDoc.paths = swaggerDoc.paths.Count == 0 ? null : swaggerDoc.paths;
                swaggerDoc.definitions = swaggerDoc.paths == null ? null : swaggerDoc.definitions;
            }
        }
