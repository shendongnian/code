    public static string ToSentence(this string value)
    {
        char[] characters = value.ToCharArray();
        // Determine where groups start
        List<int> groupStartIndexes =
            characters
                .Select((character, index) =>
                    new
                    {
                        Character = character,
                        Index = index
                    }
                )
                .Where(obj => Char.IsUpper(obj.Character))
                .Select(obj => obj.Index)
                .ToList();
        // if there is no upper case letter or
        // if value does not start with an upper case letter
        if (!groupStartIndexes.Contains(0))
        {
            groupStartIndexes.Insert(0, 0);
        }
        // To make our life easier
        groupStartIndexes.Add(value.Length);
        var groups = new List<string>();
        // Split value into groups
        for (int index = 0; index < groupStartIndexes.Count - 1; index++)
        {
            int currentGroupStartIndex = groupStartIndexes[index];
            int nextGroupStartIndex = groupStartIndexes[index + 1];
            string currentGroup =
                value
                    .Substring(
                        currentGroupStartIndex,
                        nextGroupStartIndex - currentGroupStartIndex
                    );
            groups.Add(currentGroup);
        }
        var sb = new StringBuilder(groups[0]);
        // Build the final string
        for (int currentGroupIndex = 1; currentGroupIndex < groups.Count; currentGroupIndex++)
        {
            string previousGroup = groups[currentGroupIndex - 1];
            string currentGroup = groups[currentGroupIndex];
            if (previousGroup.Length > 1 || currentGroup.Length > 1)
            {
                sb.Append(" ");
            }
            sb.Append(groups[currentGroupIndex]);
        }
        return sb.ToString();
    }
