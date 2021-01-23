    public static string getValue(List<string[]> input, string searchCriteria)
    {
        string value = input.Where(arr => arr[0] == searchCriteria).Select(arr => arr[1]).FirstOrDefault();
        return value == null ? "" : value;
    }
