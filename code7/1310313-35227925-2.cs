    IEnumerable<object> enumerable = Enumerable.Empty<string>(); // Safe, 
                                                                 // enumerable is covariant
    ICollection<object> collection = new Collection<string>();   // Error, 
                                                                 // collection isn't covariant
    Func<object> func = () => "Hi!"; // Safe, Func<T> is covariant
    Action<object> func = (string val) => { ... }; // Error, Action<T> isn't covariant
