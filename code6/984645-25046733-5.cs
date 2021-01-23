    // map makes it easy to work with pure functions
    public Optional<TOut> Map<TIn, TOut>(Func<TIn, TOut> f) where TIn : T {
        return IsPresent ? Optional.For(f(value)) : Empty();
    }
    // foreach is for side-effects
    public Optional<T> Foreach(Action<T> f) {
        if (IsPresent) f(value);
        return this;
    }
    // getOrElse for defaults
    public T GetOrElse(Func<T> f) {
        return IsPresent ? value : f();
    }
    public T GetOrElse(T defaultValue) { return IsPresent ? value: defaultValue; }
    // orElse for taking actions when dealing with `None`
    public void OrElse(Action<T> f) { if (!IsPresent) f(); }
