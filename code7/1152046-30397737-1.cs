    ResultType result = null;
    using (DisposableObject disposableObject = new DisposableObject(...))
    {
       disposableObject.UseDisposableResource();
       ...
       result = disposableObject.AccessUndisposedResource();
    }
    ...
    // Now we can access the undisposed resource here with 'result'-variable
