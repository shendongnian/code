    public static IEnumerable<T> EnumerateDescendants<T>(this T root, Func<T, IEnumerable<T>> children, int maxLevels, int currentLevel = 0)
    {
        if (currentLevel <= maxLevels)
        {
            yield return root;
            foreach (var child in children(root).SelectMany(x => x.EnumerateDescendants(children, maxLevels, currentLevel + 1)))
            {
                yield return child;
            }
        }
    }
