    public void Method(IAnimal animal)
    {
        // We don't want to call Handle with a null reference,
        // or we'd get an exception to due overload ambiguity
        if (animal == null)
        {
            throw new ArgumentNullException("animal");
        }
        // Do things with just the IAnimal properties
        Handle((dynamic) animal);
    }
    private void Handle(Dog dog)
    {
        ...
    }
    private void Handle(Elephant elephant)
    {
        ...
    }
    private void Handle(object fallback)
    {
        // This method will be called if none of the other overloads
        // is applicable, e.g. if a "new" implementation is provided
    }
