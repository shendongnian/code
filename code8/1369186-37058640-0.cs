    public static void IsNullOrEmpty<S,T>(T argument) where T : List<S>
    {
        if (argument == null || argument.Count == 0)
        {
            throw new ArgumentException("Argument " + nameof(argument) + " can't be null or empty list.");
        }
    }
