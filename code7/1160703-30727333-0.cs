    public static void PreBindModel<TViewModel, TController>(this TController controller, 
                                                             TViewModel viewModel, 
                                                             string operationName) {
        foreach (var paramToAction in typeof(TController).GetMethod(operationName).GetParameters()) {
            foreach (var bindAttribute in paramToAction.CustomAttributes.Where(x => x.AttributeType == typeof(BindAttribute))) {
                string properties;
                try {
                    properties = bindAttribute.NamedArguments.Where(x => x.MemberName == "Include").First().TypedValue.Value.ToString();
                }
                catch (InvalidOperationException) {
                    continue;
                }
                var propertyNames = properties.Split(',');
                var propertiesToReset = typeof(TViewModel).GetProperties().Where(x => propertyNames.Contains(x.Name) == false);
                foreach (var propertyToReset in propertiesToReset) {
                    propertyToReset.SetValue(viewModel, null);
                }
            }
        }
    }
