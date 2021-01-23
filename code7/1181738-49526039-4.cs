    public static bool ContainIgnoreCase(this IEnumerable<string> list, string value)
        {
            if (list == null || !list.Any())
                return false;
            if (value == null)
                return false;
            return list.Any(item => item.Equals(value, StringComparison.OrdinalIgnoreCase));
        }
