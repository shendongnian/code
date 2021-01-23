    public void Apply(ApplicationModel application) {
        foreach (var controller in application.Controllers) {
            var hasRouteAttribute = controller.Selectors.Any(x => x.AttributeRouteModel != null);
            if (hasRouteAttribute) {
                continue;
            }
            var nameSpace = controller.ControllerType.Namespace.Split('.');
            var version = nameSpace.FirstOrDefault(x => Regex.IsMatch(x, @"[v][\d*]"));
            if (string.IsNullOrEmpty(version)) {
                continue;
            }
            controller.Selectors[0].AttributeRouteModel = new AttributeRouteModel() {
                Template = string.Format(urlTemplate, apiPrefix, version, controller.ControllerName)
            };
        }
    }
