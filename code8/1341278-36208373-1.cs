    public static string Description(this Enum @enum)
    {
        try
        {
            var @string = @enum.ToString();
            var attribute =
                @enum.GetType()
                     .GetField(@string)
                     .GetCustomAttribute<DescriptionAttribute>(false);
            return attribute != null ? attribute.Description : @string;
        }
        catch // Log nothing, just return an empty string
        {
            return string.Empty;
        }
    }
