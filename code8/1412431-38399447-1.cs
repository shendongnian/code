    /// <summary>
    /// Gets the text from the <see cref="DisplayAttribute"/> ShortName associated with the enum member.
    /// </summary>
    /// <param name="value">The enum value to check.</param>
    /// <returns>The value of the Display - ShortName attribute or null if not available.</returns>
    public static string GetShortName(this Enum enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()
                        .GetShortName();
    }
