    public ErrorList(IEnumerable<ValidationFailure> errors)
    {
        // e.CustomState is of type T ?
        Errors = errors
            .Where(e => (e.CustomState is T))
            .ToDictionary(e => (T)e.CustomState, e => e.PropertyName);
        // e.CustomState is not of type T ?
        ExtraErrors = errors
            .Where(e => !(e.CustomState is T))
            .GroupBy(e => e.CustomState.GetType())
            .ToDictionary(
                g => g.Key,
                g => (IReadOnlyDictionary<object, string>)g.ToDictionary(
                          e => e.CustomState, 
                          e => e.PropertyName));
    }
