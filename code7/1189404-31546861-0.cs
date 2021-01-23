    private static string RemoveString (string input)
    {
            var indexOf = input.LastIndexOf("v", StringComparison.OrdinalIgnoreCase);
            if (indexOf < 0)
                return input;
            return input.Substring(0, indexOf);
    }
