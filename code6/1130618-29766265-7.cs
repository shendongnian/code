    using Microsoft.Immutable.Collections;
    IReadOnlyDictionary<string, T> InstantiateByName<T>(
            Func<string, T> instantiator
            params string[] names,
            IEqualityComparer<string> keyComparer = null,
            IEqualityComparer<T> valueComparer = null)
    {
        if (keyComparer == null)
        {
            keyComparer = EqualityComparer<string>.Default;
        }
        if (valueComparer == null)
        {
            valueComparer = EqualityComparer<T>.Default;
        }
        return names.ToImmutableDictionary(
            name => name,
            name => instantiator(name),
            keyComparer,
            valueComparer);
    }
