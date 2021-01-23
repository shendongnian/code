    var registrations = container.Registrations
                       .Where(x => typeof(ISample).IsAssignableFrom(x.RegisteredType));
    var classList = new List<ISample>();
    foreach (var registration in registrations)
    {
        var classObject = container.Resolve(registration.RegisteredType, registration.Name);
        classList.Add((ISample)classObject);
    }
