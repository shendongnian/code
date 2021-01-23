    [ApiExplorerSettings(IgnoreApi = true)]
    public class HelpController : ApiController
    {
        public List<ActionMethod> Get()
        {
            var apiActions = new List<ActionMethod>();
            Collection<ApiDescription> apiDescriptions = GlobalConfiguration
                               .Configuration
                               .Services
                               .GetApiExplorer()
                               .ApiDescriptions;
            foreach (var api in apiDescriptions)
            {
                List<Parameter> parameters = new List<Parameter>();
                //get the parameters for this ActionMethod
                foreach (var parameterDescription in api.ParameterDescriptions)
                {
                    Parameter parameter = new Parameter()
                    {
                        Name = parameterDescription.Name, 
                        Source = parameterDescription.Source.ToString(),
                        Type = parameterDescription.ParameterDescriptor.ParameterType.ToString(),
                        SubParameters = new List<Parameter>()
                    };
                    //get any Sub-Parameters (for complex types; this should probably be recursive)
                    foreach (var subProperty in parameterDescription.ParameterDescriptor.ParameterType.GetProperties())
                    {
                        parameter.SubParameters.Add(new Parameter()
                        {
                            Name = subProperty.Name,
                            Type = subProperty.PropertyType.ToString()
                        });
                    }
                    parameters.Add(parameter);
                }
                //add a new action to our list
                apiActions.Add(new ActionMethod()
                {
                    Name = api.ActionDescriptor.ControllerDescriptor.ControllerName,
                    Parameters = parameters, 
                    SupportedHttpMethods = string.Join(",", api.ActionDescriptor.SupportedHttpMethods)
                });
            }
            return apiActions;
        }
    }
