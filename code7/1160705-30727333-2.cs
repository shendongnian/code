    public static void PreBindModel<TViewModel, TController>(this TController controller, TViewModel viewModel, string operationName) {
        foreach (var paramToAction in typeof(TController).GetMethod(operationName).GetParameters()) {
            foreach (BindAttribute bindAttribute in paramToAction.GetCustomAttributes(true)) {//.Where(x => x.AttributeType == typeof(BindAttribute))) {
                var propertiesToReset = typeof(TViewModel).GetProperties().Where(x => bindAttribute.IsPropertyAllowed(x.Name) == false);
                foreach (var propertyToReset in propertiesToReset) {
                    propertyToReset.SetValue(viewModel, null);
                }
            }
        }
    }
