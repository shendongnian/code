        public class DiModelBinder : ComplexTypeModelBinder
        {
            public DiModelBinder(IDictionary<ModelMetadata, IModelBinder> propertyBinders) : base(propertyBinders)
            {
            }
            /// <summary>
            /// Creates the model with one (or more) injected service(s).
            /// </summary>
            /// <param name="bindingContext"></param>
            /// <returns></returns>
            protected override object CreateModel(ModelBindingContext bindingContext)
            {
                var services = bindingContext.HttpContext.RequestServices;
                var modelType = bindingContext.ModelType;
                var ctors = modelType.GetConstructors();
                foreach (var ctor in ctors)
                {
                    var paramTypes = ctor.GetParameters().Select(p => p.ParameterType).ToList();
                    var parameters = paramTypes.Select(p => services.GetService(p)).ToArray();
                    if (parameters.All(p => p != null))
                    {
                        var model = ctor.Invoke(parameters);
                        return model;
                    }
                }
                return null;
            }
        }
