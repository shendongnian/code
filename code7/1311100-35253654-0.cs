    var result = dept.Projects
        .Cast<Project>()
        .Where(project => project.State == pState.state_initiated)
        .SelectMany(project => project.Properties().OfType<Property>())
        .FirstOrDefault(property => property.Name == "InitiatorName");
