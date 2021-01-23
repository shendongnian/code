    public override void Load()
    {
        var decorators = new[]
        {
            typeof(FirstDecorator),
            typeof(SecondDecorator)
        };
        Decorate<IService, FirstService>("First", decorators);
        Decorate<IService, SecondService>("Second", decorators);
        Decorate<IService, ThirdService>("Third", decorators);
    }
    private void Decorate<S, T>(string name, params Type[] decorators)
        where T : S
    {
        var allImplementations = new[] { typeof(T) }.Union(decorators);
        foreach (var implementation in allImplementations)
        {
            Bind<S>().To(implementation).When(r => Need(implementation, r, name, allImplementations));
        }
        Bind<S>().To(allImplementations.Last()).Named(name);
    }
    private bool Need(Type implementation, IRequest request, string name, IEnumerable<Type> implementations)
    {
        var implementationsList = implementations.ToList();
        var depth = implementationsList.Count - implementationsList.IndexOf(implementation);
        return request.Depth == depth && request.ActiveBindings.Any(b => b.Metadata.Name == name);
    }
