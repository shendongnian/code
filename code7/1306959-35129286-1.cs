    public static class Helpers
    public static IEnumerable<Person> GetDescendants(this Person person)
    {
        foreach (var child in person.Children)
        {
            yield return child;
            foreach (var descendant in child.GetDescendants())
            {
               yield return descendant;
            }
        }
    }
